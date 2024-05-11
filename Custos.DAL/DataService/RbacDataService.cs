using System.Text;
using AutoMapper;
using custos.Models;
using custos.Models.Master;
using custos.Models.RbacModel;
using Custos.DAL.Unitofworks;
using Microsoft.Extensions.Configuration;
using System.Collections;
using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Hosting;
//using custos.DAL.Migrations;



namespace custos.DAL.DataService
{
	public class RbacDataService : IRbacDataService
    {
        readonly IUnitOfWorks _uow;
        readonly IMapper _mapper;
        readonly string encryptkey;
        readonly IConfiguration _config;
        
       
        public RbacDataService(IUnitOfWorks uow, IMapper mapper, IConfiguration configuration)
        {
            _uow = uow;
            _mapper = mapper;
            _config = configuration;
		}

        public async Task<Response> ValidateSignIn(LoginDTO masterDTO)
        {
            Response response = new Response();
            try
            {
                UsersDTO usdata = new UsersDTO();
                var dbdata = _uow.users.GetFirstOrDefault(x => x.Email.ToLower() == masterDTO.UserName.ToLower() && x.Password == EncryptDecrypt.EncryptData(masterDTO.Password, encryptkey));
                if (dbdata == null)
                {
                    response.StatusCode = "Failure";
                    response.Message = "Invalid username or password";
                }
                else
                {
                    usdata = _mapper.Map<UsersDTO>(dbdata);
                    response.StatusCode = "Success";
                    response.Message = "Data Sent";
                    response.Data = usdata;
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = "Failed";
                var errormessage = await _uow.AddException(ex);
                response.Message = errormessage;
            }
            return response;

        }

        public async Task<Response> AgentRegistration(AgentRegistrationDTO data)
        {
            Response response = new Response();
            try
            {
                string encryptkey = "Custos@#app$2023";
                var clientdata = _uow.clientLicense.GetFirstOrDefault(x => x.Key == data.UniqueKey && x.IsActive == false);
                if (clientdata == null)
                {
                    response.Status = "Failed";
                    response.Message = "Invalid_Key";
                    return response;

                }

                else
                {
                    var userdata = _uow.users.GetFirstOrDefault(x => x.Email == data.Email);
                    var usertype = _uow.userType.GetFirstOrDefault(x => x.Name.ToLower() == data.UserType.ToLower());
                    if(userdata != null)
                    {
                        response.Status = "Failed";
                        response.Message = "Email Already Exist";
                        return response;
                    }

                    var password = GenerateRandomPassword();
                    Users user = new Users();
                    user.UserName = data.Name;
                    user.ClientId = clientdata.ClientId;
                    user.Email = data.Email;
                    user.ContactNo = data.ContactNo;
                    user.Systemid = data.SystemId;
                    user.CreatedOn = data.Date;
                    user.Addresses = data.Location;
                    user.Password = EncryptDecrypt.EncryptData(password, encryptkey);
                    user.UserType = usertype.Id == null ? 0 : usertype.Id;
                   var finaluser =  _uow.users.Add(user);
                    
                   clientdata.UserId = finaluser.Id;
                    clientdata.IsActive = true;
                    clientdata.ActivatedOn = data.Date;
                    _uow.clientLicense.Update(clientdata);
                    await _uow.SaveAsync();

                    var subject = "Welcome to RikArena - Your Account Details";
                    var body = "your Password is " + password + "\n  Subscription Keys \n" + clientdata.Key;
                    
                    var sendemail = SendMail(user.Email, subject, body);
                    response.StatusCode = "Save Successfully";
                    response.Message = "Data Added";
                    return response;

                }
               


            }
            catch(Exception ex)
            {
                response.StatusCode = "Failed";
                var errormessage = await _uow.AddException(ex);
                response.Message = errormessage;
            }
            return response;
        }

        public async Task<Response> CreateClient(ClientDTO clientDTO)
        {
            Response response = new Response();
            Client client = new Client();
            Users user = new Users();
			string encryptkey = "Custos@#app$2023";
            List<string> KeysList = new List<string>();


            try
			{
				var userTypeId = _uow.userType.GetAllAsync(x => x.Name.ToLower() == "client admin").Result.FirstOrDefault();
                if(userTypeId == null)
                {
					response.StatusCode = "";
					response.Message = "UserType is not Valid";
					response.Data = null;
                    return response;
				}

				var dbdata = _mapper.Map<Client>(clientDTO);
                if (dbdata.Id == 0)
                {
					client = await _uow.client.AddAsync(dbdata);

                    for(int i=0;i< client.NoKey;i++)
                    {
                       
                        ClientLicense clientLicense=new ClientLicense();
                        clientLicense.ClientId = client.Id;
                        clientLicense.Key = GenerateKey();
                        await _uow.clientLicense.AddAsync(clientLicense);
                        await _uow.SaveAsync();
                        KeysList.Add(clientLicense.Key);
                    }
                    var password = GenerateRandomPassword();
                    user.Password = EncryptDecrypt.EncryptData(password, encryptkey);
					user.ClientId=client.Id;
					user.UserType= userTypeId==null? 0 :userTypeId.Id;
                    user.UserName = client.Name;
                    user.Addresses=client.Address1+" "+client.Address2;
                    user.ContactNo = client.MobileNo;
                    user.Email = client.Email;
					_uow.users.Add(user);
					await _uow.SaveAsync();

                   
					var subject = "Welcome to RikArena - Your Account Details";
					var body = "your Password is " + password + "\n List of Subscription Keys \n";
                    foreach (var detail in KeysList)
                    {
                        body += "\n\t\t" + detail;
                    }
                    var sendemail = SendMail(client.Email, subject, body);



				}
				

				response.StatusCode = "Success";
				response.Message = "Client Saved Successfully";
				response.Data = dbdata;
			}
            catch (Exception ex)
            {
                response.StatusCode = "Failed";
                var errormessage = await _uow.AddException(ex);
                response.Message = errormessage;
            }
            return response;

        }

        public async Task<Response> GetAllClient()
        {
            Response response = new Response();
			try
            {
				var data =  _uow.client.GetAllNoTracking();

				var joinData = data.Join(await _uow.state.GetAllAsync(), cl => cl.State, s => s.Id, (cli, st) => new { cl = cli, s = st })
				   .Select(s => new ClientDTO
				   {
					   Id = s.cl.Id,
					   Name = s.cl.Name,
					   Email = s.cl.Email,
					   Address1 = s.cl.Address1,
					   Address2 = s.cl.Address2,
					   NoKey = s.cl.NoKey,
					   City = s.cl.City,
					   Country = s.cl.Country,
					   Pincode = s.cl.Pincode,
					   MobileNo = s.cl.MobileNo,
					   State = s.s.Id,
					   StateName = s.s.Name,
				   }).ToList();


                response.StatusCode = "Success";
                response.Message = "Data Sent";
                response.Data = joinData;
            }
            catch (Exception ex)
            {
                response.StatusCode = "Failed";
                var errormessage = await _uow.AddException(ex);
                response.Message = errormessage;

            }
            return response;
        }

        public async Task<Response> GetMenuList(int userTypeId, int UserId)
        {
            Response response = new Response();
            try
            {
                var dbdata = _uow.menu
                    .GetAllNoTracking(x =>  x.UserTypeId == userTypeId && x.UserId == UserId && x.IsActive == true, null, "MenuGroup,SubComponentMaster,LookupMaster");

                var menuList = _mapper.Map<List<MenuDTO>>(dbdata);
                response.StatusCode = "Success";
                response.Message = "Data Sent";
                response.Data = menuList;
            }
            catch (Exception ex)
            {
                response.StatusCode = "Failed";
                var errormessage = await _uow.AddException(ex);
                response.Message = errormessage;

            }
            return response;
        }
        public async Task<Response> GetMenuById(int id)
        {
            Response response = new Response();
            try
            {
                var dbdata = await _uow.menu.GetFirstOrDefaultAsync(x => x.Id == id);
                response.StatusCode = "Success";
                response.Message = "Data Sent";

                var datadto = _mapper.Map<MenuDTO>(dbdata);
                response.Data = datadto;
            }
            catch (Exception ex)
            {
                response.StatusCode = "Failed";
                var errormessage = await _uow.AddException(ex);
                response.Message = errormessage;
            }
            return response;
        }
		public async Task<Response> GetAllState()
		{
			Response response = new Response();
			try
			{
				var dbdata = _uow.state.GetAll();

				response.StatusCode = "Success";
				response.Message = "Data Sent";
				response.Data = dbdata;
			}
			catch (Exception ex)
			{
				response.StatusCode = "Failed";
				var errormessage = await _uow.AddException(ex);
				response.Message = errormessage;

			}
			return response;
		}
		public async Task<Response> GetClientLicence(int clientId)
		{
			Response response = new Response();
			try
			{
				var data = await _uow.clientLicense.GetAllAsync(x => x.ClientId == clientId);
                var JoinData = data.GroupJoin(await _uow.users.GetAllAsync(),
                         c => c.UserId,
                         cl => cl.Id,
                         (c, cl) => new {
                             client = c, 
                             clientL = cl
                         }).SelectMany(temp => temp.clientL.DefaultIfEmpty(),
                    (temp, p) => new
                    {
                        C = temp.client,
                        U = p
                    }).Select(x => new ClientLicenseDTO
                    {
                        Id=x.C.Id,
						ClientId = x.C.ClientId,
						Key = x.C.Key,
						ActivatedOn = x.C.ActivatedOn,
						IsActive = x.C.IsActive,
						UserName=x.U==null?"":x.U.UserName,
						UserId= x.U == null ? 0 : x.U.Id
					}).ToList();
                
				if (data != null && data.Count() > 0)
				{
					response.Status = "Success";
					response.Message = "Data Fetch Successfully";
					response.Data = JoinData;
				}
				else
				{
					response.Status = "Success";
					response.Message = "No Record Found!!";
					response.Data = data;
				}
			}
			catch (Exception ex)
			{
				response.Status = "Failed";
				var errormessage = await _uow.AddException(ex);
				response.Message = errormessage;
			}
			return response;

		}

		public static string GenerateRandomPassword(int length = 6)
		{

             Random random = new Random();
		     string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()-_=+";

		    StringBuilder password = new StringBuilder();
			for (int i = 0; i < length; i++)
			{
				password.Append(characters[random.Next(characters.Length)]);
			}
			return password.ToString();
		}

		public bool SendMail(string ToEmail, string subject, string Message)
		{
			string user = "omegasp9@gmail.com";
			string password = "bvqqzicqpvswaqit";
			SmtpClient SmtpServer = new SmtpClient();
			SmtpServer.Credentials = new NetworkCredential(user, password);
			SmtpServer.Port = 587;// 25;
			SmtpServer.Host = "smtp.gmail.com";
			SmtpServer.EnableSsl = true;
			MailMessage mail = new MailMessage();
			try
			{
				mail.From = new MailAddress(user, subject, System.Text.Encoding.UTF8);
				mail.To.Add(new MailAddress(ToEmail));
				mail.Subject = subject;
				mail.Body = "<html><body>" + Message + "</body></html>";
				mail.IsBodyHtml = true;
				mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
				SmtpServer.Send(mail);
			}
			catch (Exception ex)
			{
				return false;
			}
			return true;
		}


        public string GenerateKey()
        {
            string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
         Random _random = new Random();


        char[] keyChars = new char[16];
            for (int i = 0; i < 16; i++)
            {
                keyChars[i] = Chars[_random.Next(Chars.Length)];
            }
            return new string(keyChars);
        }





    }
}
