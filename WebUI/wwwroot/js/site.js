// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function SelectValueToInt(idSelectValue, idHiddenInput) {
    //Getting the Htlm element
	var dropdown = document.getElementById(idSelectValue);
	var input = document.getElementById(idHiddenInput);
    
	//Checking if the dropdown is null
	if ((dropdown != null || dropdown != undefined) && (input != null || input != undefined)) {
		input.value = +dropdown.value;
		return true;
	}
	return false;
}