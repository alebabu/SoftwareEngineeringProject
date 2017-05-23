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
	selectizeDropdown('#ctl00_cpMainContent_addShipDropDown');

	var $select = $('#ctl00_cpMainContent_addShipDropDown').selectize();
 	var control = $select[0].selectize;
 	control.clear();
});