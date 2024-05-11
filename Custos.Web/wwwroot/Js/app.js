
let isOpen = false;
function sideBarToggle() {
	let sidebar = document.querySelector(".sidebar");
	sidebar.classList.toggle("open");
	isOpen = !isOpen;
}



function selectedSidebarItems() {
	const listItems = document.querySelectorAll('.nav-list li a');

	listItems.forEach(item => {
		item.addEventListener('click', function (event) {
			event.preventDefault();
			listItems.forEach(i => i.classList.remove('active'));
			item.classList.add('active');
		});
	});

}

function saveAsFile(fileName, data, type) {
	var blob = new Blob([data], { type: type });
	var link = document.createElement("a");
	link.href = window.URL.createObjectURL(blob);
	link.download = fileName;
	link.click();
}


function ToggleVisibility() {
	document.getElementById('installed').style.display = 'block';
	//document.getElementById('uninstalled').style.display = 'none';
	document.getElementById('online').style.display = 'none';
	document.getElementById('offline').style.display = 'none';
}




function ToggleVisibility2() {
	document.getElementById('online').style.display = 'block';
	document.getElementById('offline').style.display = 'none';
	document.getElementById('installed').style.display = 'none';
	//document.getElementById('uninstalled').style.display = 'none';
}

function ToggleVisibility3() {
	document.getElementById('online').style.display = 'none';
	document.getElementById('offline').style.display = 'block';
	document.getElementById('installed').style.display = 'none';
	//document.getElementById('uninstalled').style.display = 'none';
}

function ToggleVisibility4() {
	//document.getElementById('online').style.display = 'none';
	//document.getElementById('offline').style.display = 'block';
	//document.getElementById('installed').style.display = 'none';
	//document.getElementById('uninstalled').style.display = 'none';
}

function NotificationCount() {
	// Access the SVG's text element
	var notiCountElement = document.getElementById('noticount');

	// Check if the element exists
	if (notiCountElement) {
		// Optionally, modify the element's style or content
		notiCountElement.style.fill = 'black'; // Change the text color to red
		notiCountElement.textContent = '5';   // Change the text content

		// Display an alert
		alert('Texting');
	} else {
		// Alert if the element does not exist (useful for debugging)
		alert('Element not found');
	}
}


