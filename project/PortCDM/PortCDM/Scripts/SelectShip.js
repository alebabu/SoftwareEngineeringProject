function selectizeDropdown (dropdownId) {
	$(dropdownId).selectize({
	    placeholder: "Enter imo...",
	    persist: false,
	    create: function(input) {
	        return {
	            value: input,
	            text: input
	        }
	    }
	});

}

$(function() {

	if ($('#ctl00_cpMainContent_addShipDropDown')) {
		var id = '#ctl00_cpMainContent_addShipDropDown'
	} else {
		var id = '#cpMainContent_addShipDropDown'
	}
	//selectizeDropdown('#ctl00_cpMainContent_addShipDropDown');
	selectizeDropdown(id);

	//var $select = $('#ctl00_cpMainContent_addShipDropDown').selectize();
	var $select = $(id).selectize();
 	var control = $select[0].selectize;
 	control.clear();
});