function selectizeDropdown (dropdownId) {
	$(dropdownId).selectize({
	    delimiter: ',',
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
	selectizeDropdown('#ctl00_cpMainContent_addShipDropDown')
});