function popFieldMenu_EditClick() {
    popFieldMenu.Hide(), dtgFieldMenuEdit.PerformCallback(), popFieldMenuEdit.Show()
}

function btnNewField_Click() {
    dtgFieldMenuEdit.AddNewRow()
}

function dtgFieldMenuEdit_CustomButtonClick() {
    dtgFieldMenuEdit.GetRowValues(dtgFieldMenuEdit.GetFocusedRowIndex(), "MENUENTRY", dtgFieldMenuEdit_OnGetRowValues)
}

function dtgFieldMenuEdit_OnGetRowValues(values) {
    eval(lstFieldMenu.mainElement.getAttribute("MasterClientID")).SetText(values), popFieldMenuEdit.Hide()
}

function btnShowFieldMenu_Click(s, e) {
    var menuNumber, masterControl, masterClientID = s.mainElement.getAttribute("MasterClientID"),
        eleId = s.mainElement.id;
    if (masterClientID) masterControl = eval(masterClientID), menuNumber = masterControl.mainElement.getAttribute("MenuNumber"), hdfFLP.Set("FLP", masterControl.mainElement.getAttribute("FLP"));
    else {
        masterClientID = eleId.slice(eleId.lastIndexOf("ASPxText"), eleId.lastIndexOf("_"));
        var customMenus = sessionStorage.getItem("MenuNumbersCustom");
        customMenus && (menuNumber = JSON.parse(customMenus)[masterClientID])
    }
    hdfFLP.Set("MenuNumber", menuNumber), 51 == menuNumber || 23 == menuNumber || 25 == menuNumber || 11 == menuNumber || 180 == menuNumber || 181 == menuNumber ? btnEditFieldsMenu.SetVisible(!1) : btnEditFieldsMenu.SetVisible("true" == lblRoleValue.GetText().toLowerCase()), popFieldMenu.SetPopupElementID(eleId), popFieldMenu.Show(), lstFieldMenu.mainElement.setAttribute("MasterClientID", masterClientID), lstFieldMenu.PerformCallback(), popFieldMenuEdit.SetPopupElementID(eleId)
}

function btnShowFieldMenuForForceMenu_Click(s, e) {
    var masterClientID = void 0 === s.globalName ? "" : s.globalName.substr(0, s.globalName.length - 7),
        masterControl = eval(masterClientID);
    masterControl.SetText(lblValue_For_Menu.GetText()), 8 == e.htmlEvent.keyCode && (masterControl.SetText(""), lblValue_For_Menu.SetText(""), OnEditorValueChanged(s, e));
    var menuNumber = masterControl.mainElement.getAttribute("MenuNumber");
    menuNumber <= 0 || (hdfFLP.Set("MenuNumber", menuNumber), hdfFLP.Set("FLP", masterControl.mainElement.getAttribute("FLP")), 51 == menuNumber || 23 == menuNumber || 25 == menuNumber || 11 == menuNumber || 180 == menuNumber || 181 == menuNumber ? btnEditFieldsMenu.SetVisible(!1) : btnEditFieldsMenu.SetVisible("true" == lblRoleValue.GetText().toLowerCase()), popFieldMenu.GetVisible() || (popFieldMenu.SetPopupElementID(s.mainElement.id.substr(0, s.mainElement.id.length - 10) + "btnImageMenu"), popFieldMenu.Show(), lstFieldMenu.mainElement.setAttribute("MasterClientID", masterClientID), lstFieldMenu.PerformCallback(), popFieldMenuEdit.SetPopupElementID(s.mainElement.id)))
}

function lstFieldMenu_SelectedIndexChanged() {
    var selectedItem = lstFieldMenu.GetSelectedItem().text,
        whiffletreeIndex = selectedItem.indexOf("- "),
        reslutText;
    reslutText = whiffletreeIndex > 0 && ("166" == hdfFLP.Get("MenuNumber") || "169" == hdfFLP.Get("MenuNumber") || "170" == hdfFLP.Get("MenuNumber")) ? selectedItem.substr(whiffletreeIndex + 1, selectedItem.length - whiffletreeIndex).replace(/(^\s*)|(\s*$)/g, "") : lstFieldMenu.GetSelectedItem().text, "246" == hdfFLP.Get("MenuNumber") || "247" == hdfFLP.Get("MenuNumber") || "248" == hdfFLP.Get("MenuNumber") || "292" == hdfFLP.Get("MenuNumber") || "293" == hdfFLP.Get("MenuNumber") || "294" == hdfFLP.Get("MenuNumber") || "342" == hdfFLP.Get("MenuNumber") || "343" == hdfFLP.Get("MenuNumber") || "344" == hdfFLP.Get("MenuNumber") || "462" == hdfFLP.Get("MenuNumber") || "463" == hdfFLP.Get("MenuNumber") || "465" == hdfFLP.Get("MenuNumber") || "466" == hdfFLP.Get("MenuNumber") ? "" == eval(lstFieldMenu.mainElement.getAttribute("MasterClientID")).GetText() ? eval(lstFieldMenu.mainElement.getAttribute("MasterClientID")).SetText(reslutText) : eval(lstFieldMenu.mainElement.getAttribute("MasterClientID")).SetText(eval(lstFieldMenu.mainElement.getAttribute("MasterClientID")).GetText() + "\r\n" + reslutText) : eval(lstFieldMenu.mainElement.getAttribute("MasterClientID")).SetText(reslutText), "1000" == hdfFLP.Get("MenuNumber") && ASPxMemo2Equipment.SetText(ASPxMemo2Equipment.GetText() + " " + reslutText), "177" == hdfFLP.Get("MenuNumber") && "ebtxtConfigRecORIFDESIGNATION" == lstFieldMenu.mainElement.getAttribute("MasterClientID") && ebtxtConfigRecORIFICEAREA.SetText(""), "177" == hdfFLP.Get("MenuNumber") && "ebtxtConfigShiORIFDESIGNATION" == lstFieldMenu.mainElement.getAttribute("MasterClientID") && ebtxtConfigShiORIFICEAREA.SetText(""), "322" == hdfFLP.Get("MenuNumber") && "txtHandledBy" == lstFieldMenu.mainElement.getAttribute("MasterClientID") && chkHandled.SetChecked(!0), popFieldMenu.Hide()
}

function lstPartNameMenu_SelectedIndexChanged() {
    eval(lstPartNameMenu.mainElement.getAttribute("MasterClientID")).SetText(lstPartNameMenu.GetSelectedItem().text), popPartNamesMenu.Hide()
}
var raiseSelectedIndexChanged = !1;

function btnShowUniqueEntry_Click(s, e, grid) {
    var masterControl;
    raiseSelectedIndexChanged = !1;
    var masterClientID = s.mainElement.getAttribute("MasterClientID"),
        eleId = s.mainElement.id,
        key = "";
    if (grid) {
        var index = grid.GetFocusedRowIndex();
        key = index > -1 ? grid.GetRowKey(index) : ""
    }
    if (masterClientID) masterControl = eval(masterClientID), hdfFLP.Set("DataField", masterControl.mainElement.getAttribute("DataField") + "|" + key);
    else {
        masterClientID = eleId.slice(eleId.lastIndexOf("ASPxText"), eleId.lastIndexOf("_"));
        var customMenus = sessionStorage.getItem("DataFieldsCustom");
        customMenus && hdfFLP.Set("DataField", JSON.parse(customMenus)[masterClientID])
    }
    popUniqueEntry.SetPopupElementID(eleId), popUniqueEntry.Show(), lstUniqueEntry.PerformCallback(), lstUniqueEntry.mainElement.setAttribute("MasterClientID", masterClientID)
}

function chkShowAll_CheckedChanged() {
    lstUniqueEntry.PerformCallback()
}

function lstUniqueEntry_EndCallback(e, t) {
    e.itemsValue.length <= 5 ? $("#" + e.GetMainElement().id).height(80) : e.itemsValue.length > 20 ? $("#" + e.GetMainElement().id).height(400) : $("#" + e.GetMainElement().id).height(20 * e.itemsValue.length), raiseSelectedIndexChanged = !0
}

function lstFieldMenu_EndCallback(e, t) {
    e.itemsValue.length < 5 ? $("#" + e.GetMainElement().id).height(80) : e.itemsValue.length > 20 ? $("#" + e.GetMainElement().id).height(400) : $("#" + e.GetMainElement().id).height(20 * e.itemsValue.length)
}

function lstUniqueEntry_SelectedIndexChanged() {
    if (raiseSelectedIndexChanged) {
        try {
            var selectedText = lstUniqueEntry.GetSelectedItem().text,
                maxlength = $("#" + eval(lstUniqueEntry.mainElement.getAttribute("MasterClientID")).mainElement.id + "_I").attr("maxlength");
            "-1" == maxlength && (maxlength = eval(lstUniqueEntry.mainElement.getAttribute("MasterClientID")).txtBox.inputMaxLength), "" == maxlength || "-1" == maxlength ? eval(lstUniqueEntry.mainElement.getAttribute("MasterClientID")).SetText(selectedText) : (selectedText.length > maxlength && (selectedText = selectedText.substr(0, maxlength)), eval(lstUniqueEntry.mainElement.getAttribute("MasterClientID")).SetText(selectedText))
        } catch (e) {
            eval(lstUniqueEntry.mainElement.getAttribute("MasterClientID")).SetText(selectedText)
        }
        popUniqueEntry.Hide()
    }
}