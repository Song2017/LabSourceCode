if ($.cookie('AlertNotEditPermissionMsg') == 'true') {
    $.cookie('AlertNotEditPermissionMsg').value = 'false';
    VKAlert('');
    return false;
}

if ('<%= CanEdit.ToString().ToLower() %>' != 'true') {
    VKAlert('Your User ID & Role do not have permission to perform that task.')
    return false;
}