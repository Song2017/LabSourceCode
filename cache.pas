unit Av2SpringLookup;

//v5.15eK - added consolidated spring charts AND "existing spring lookup"

// in the future? 5.5aK?  add ability to edit Consolidated and add other valves/springs

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  StdCtrls, ExtCtrls, Buttons, RzLabel, RzPanel, ComCtrls, Wwdbigrd, db,
  Wwdbgrid, Grids, DBGrids, printers, Menus, RzCmboBx, RzBorder, RzTabs,
{$IFDEF ISORACLE}
  OracleData, Oracle,oraclewwdata,
{$ENDIF}
{$IFDEF ISKINTERBASE}
  IBODataset, IB_Components,
{$ENDIF}
{$IFDEF ISPARADOX}
  Wwquery, Wwtable,    //v5.00 brought wwTable here
{$ENDIF}

  DBCtrls, Wwdatsrc, Mask, RzEdit, RzSpnEdt, RzDBCmbo;

type
  TfSpringLookup = class(TForm)
    rzpanTop: TRzPanel;
    Shape6: TShape;
    lbTitle: TRzLabel;
    RzPanel2: TRzPanel;
    BitBtn2: TBitBtn;
    sbSQL: TSpeedButton;
    rzpcSearch: TRzPageControl;
    tsConLookup: TRzTabSheet;
    TabSheet2: TRzTabSheet;
    Label1: TLabel;
    rgHowRevExisting: TComboBox;
    edSpringRevExisting: TEdit;
    rzpanResults: TRzPanel;
    RzPanel1: TRzPanel;
    sbPrint: TSpeedButton;
    sbExcel: TSpeedButton;
    Label3: TLabel;
    Label4: TLabel;
    Label5: TLabel;
    lbCount: TLabel;
    lbP: TLabel;
    lbO: TLabel;
    Bevel8: TBevel;
    bbTransfer: TBitBtn;
    cbFreezeColumns: TCheckBox;
    wgrdParts: TwwDBGrid;
    wgrdPartsIButton: TwwIButton;
    Label6: TLabel;
    lbTagNo: TLabel;
    DBText1: TDBText;
    Label249: TLabel;
    dbtModel: TDBText;
    Label457: TLabel;
    Label458: TLabel;
    Label460: TLabel;
    Label459: TLabel;
    Label151: TLabel;
    Label376: TLabel;
    Label113: TLabel;
    Label21: TLabel;
    Label9: TLabel;
    lbSetPress: TLabel;
    Label115: TLabel;
    Label304: TLabel;
    Label306: TLabel;
    Label310: TLabel;
    Label161: TLabel;
    DBText2: TDBText;
    DBText3: TDBText;
    DBText5: TDBText;
    DBText6: TDBText;
    DBText7: TDBText;
    DBText8: TDBText;
    DBText9: TDBText;
    dbtService: TDBText;
    dbtMan: TDBText;
    dbtOrifice: TDBText;
    dbtTemp: TDBText;
    DBText14: TDBText;
    dbTextSet: TDBText;
    dbTextCDTP: TDBText;
    dbtORing: TDBText;
    lbGridCols: TListBox;
    Label7: TLabel;
    rzPanSearch: TRzPanel;
    bbSearch: TBitBtn;
    Label2: TLabel;
    Label16: TLabel;
    rzcbConsolSeries: TRzComboBox;
    tsConRLookup: TRzTabSheet;
    TabSheet4: TRzTabSheet;
    Label18: TLabel;
    rzcbOrifice: TRzComboBox;
    Label19: TLabel;
    rzcbInletSize: TRzComboBox;
    cbConsolidatedLookupMeetsPressure: TCheckBox;
    Label22: TLabel;
    Label23: TLabel;
    rzcbTempClass: TRzComboBox;
    sbSHow: TSpeedButton;
    Label24: TLabel;
    cbUM: TComboBox;
    cbORing: TComboBox;
    Label26: TLabel;
    Label27: TLabel;
    Label17: TLabel;
    Label28: TLabel;
    rzcbService: TRzComboBox;
    sbClearConsolSearch: TSpeedButton;
    bbSetConsolSearch: TSpeedButton;
    Label31: TLabel;
    dbtInlet: TDBText;
    RzPanel3: TRzPanel;
    bbConSolReverse: TBitBtn;
    cbConSolReverse: TComboBox;
    edConSolReverse: TEdit;
    Label30: TLabel;
    wwDBGrid1: TwwDBGrid;
    wwIButton1: TwwIButton;
    Label13: TLabel;
    Label8: TLabel;
    edSpringRevExistingMfg: TEdit;
    edSpringRevExistingService: TEdit;
    Label10: TLabel;
    Label12: TLabel;
    Label11: TLabel;
    edSpringRevExistingModel: TEdit;
    edSpringRevExistingSet: TRzSpinEdit;
    Label14: TLabel;
    Label15: TLabel;
    Label29: TLabel;
    edSpringRevExistingOrifice: TEdit;
    Label20: TLabel;
    Label32: TLabel;
    edSpringRevExistingInlet: TEdit;
    wwDBGrid2: TwwDBGrid;
    wwIButton2: TwwIButton;
    RzLabel1: TRzLabel;
    RzLabel2: TRzLabel;
    cbSortCount: TCheckBox;
    lbORing: TRzLabel;
    dbtProduct: TDBText;
    rzlbORing1900: TRzLabel;
    panSearchCBs: TRzPanel;
    cbExcludeBlankSprings: TCheckBox;
    cbOwnerOnly: TCheckBox;
    cbPlantOnly: TCheckBox;
    Memo1: TMemo;
    Memo2: TMemo;
    procedure FormCreate(Sender: TObject);
    procedure FormKeyPress(Sender: TObject; var Key: Char);
    procedure lbTitleClick(Sender: TObject);
    procedure sbPrintClick(Sender: TObject);
    procedure sbExcelClick(Sender: TObject);
    procedure bbSearchClick(Sender: TObject);
    procedure FormDestroy(Sender: TObject);
    procedure wgrdPartsRowChanged(Sender: TObject);
    procedure cbFreezeColumnsClick(Sender: TObject);
    procedure sbSQLClick(Sender: TObject);
    procedure wgrdPartsTitleButtonClick(Sender: TObject;
      AFieldName: String);
    procedure rzpcSearchChanging(Sender: TObject; NewIndex: Integer;
      var AllowChange: Boolean);
    procedure rzcbConsolSeriesChange(Sender: TObject);
    procedure FormShow(Sender: TObject);
    procedure rzcbOrificeDropDown(Sender: TObject);
    procedure rzcbOrificeChange(Sender: TObject);
    procedure rzcbInletSizeDropDown(Sender: TObject);
    procedure rzcbTempClassDropDown(Sender: TObject);
    procedure sbSHowClick(Sender: TObject);
    procedure rzcbServiceDropDown(Sender: TObject);
    procedure sbClearConsolSearchClick(Sender: TObject);
    procedure bbConSolReverseClick(Sender: TObject);
    procedure bbSetConsolSearchClick(Sender: TObject);
    procedure wwDBGrid1RowChanged(Sender: TObject);
    procedure cbSortCountClick(Sender: TObject);
    procedure wwDBGrid2RowChanged(Sender: TObject);
    procedure cbOwnerOnlyClick(Sender: TObject);
    procedure bbTransferClick(Sender: TObject);
  private
    { Private declarations }
    lIgnoreOnChange: boolean;
    sEQOn, sRepairOn, sLimEqTo: string;
    sOwnerOn, sPlantOn, sModelNumberOn, sSpringOn: string;
    bInTransfer: boolean;
    ds: twwDataSource;      // quick reference to dmMain.wdsRVD
    dPress: double;
    bAnd: boolean;

    procedure OpenOP;
    procedure SetDS( iType: integer );  // iType 0=read only, 1=edit
    procedure FieldNamesToForm;
    procedure SaveGridCols;
  public
    { Public declarations }
    sInfo: array[0..15] of string; // olds owner name and plant info
    sUK, sEK, sOK, sPK: string;
    bCalledFromPartsForm: boolean;
    sSortBy, sDesc, sSortingByAlready: string;
    sSortByCL, sDescCL, sSortingByAlreadyCL: string;
    iOptionIndexWasB4DropDown: integer;
    bReverseConsol: boolean;

    procedure OpenConsolLookup;
    procedure AddConsolModelSeries( tsl: tStrings );
    procedure AddConsolPressure( tsl: tStrings );
    procedure AddConsolInlet( tsl: tStrings );
    procedure AddConsolOrifice( tsl: tStrings );
    procedure AddConsolTempClass( tsl: tStrings );
    procedure AddConsolService( tsl: tStrings );
  end;

var
  fSpringLookup: TfSpringLookup;

implementation

uses Av2Main, Av2Find, Av2Filter, Av2OrderBy, Av2GridCol, Av2Excel,
     Av2SpringRep, Av2EquipCommonRoutines, Av2GenericTagProcessor,
     Av2Parts, Av2Wizard,

{$IFDEF ISPARADOX}
  Av2DataModMain;
{$ENDIF}
{$IFDEF ISKINTERBASE}
  Av2DataModMain_IBO;
{$ENDIF}
{$IFDEF ISORACLE}
  Av2DataModMain_ORA;
{$ENDIF}


{$R *.DFM}

procedure TfSpringLookup.FormCreate(Sender: TObject);
var
  i, iField: integer;
begin
  { ignore any onchage }
  lIgnoreOnChange := True;
  bInTransfer := False;
  rzpcSearch.tabINdex := 0;
  bReverseConsol := False;

  { center the form on the screen }
  left := (screen.width-width) div 2 - 1;
  top := (screen.height-height) div 2 - 1;
  { setup font too }
  font := fMain.DefaultFont;
  font.size := 10;

  // get where we currently are
  try
    if fEquip.qe.state in [dsInsert,dsEdit] then begin
      sRepairOn := trim(fEquip.qe.FieldByName('UniqueKey').text);
      sEQOn := trim(fEquip.qe.FieldByName('EquipmentKey').text);
      sOwnerOn := trim(fEquip.qe.FieldByName('OwnerKey').text);
      sPlantOn := trim(fEquip.qe.FieldByName('PlantKey').text);
      sModelNumberOn := trim(fEquip.qe.FieldByName('ModelNumber').text);
      sSpringOn := uppercase(trim(fEquip.qe.FieldByName('SpringNumber').text) );

      SetDS(1);   // change from display'ing "q" to "qe" for data aware components
      bbTransfer.visible := True;
      end
    else begin
      sRepairOn := trim(fEquip.q.FieldByName('UniqueKey').text);
      sEQOn := trim(fEquip.q.FieldByName('EquipmentKey').text);
      sOwnerOn := trim(fEquip.q.FieldByName('OwnerKey').text);
      sPlantOn := trim(fEquip.q.FieldByName('PlantKey').text);
      sModelNumberOn := trim(fEquip.q.FieldByName('ModelNumber').text);
      sSpringOn := uppercase( trim(fEquip.q.FieldByName('SpringNumber').text) );
    end;

    //v5.04K what if the current grid has no entries?
    if sOwnerOn = '' then begin
      // the only case where this is null is if there is no entry in grid
      // in that case, use the currently selected Owner/Plant (if there is one)
      // if there isn't (ie. use all, for example) then, let the SQL generate
      // handle
      sPlantOn := fMain.sPlantID;
      sOwnerOn := fMain.sOwnerID;
    end;
  except
    MessageDlg( 'Could NOT find current entry: '+exception(exceptobject).message,
                  mtError, [mbOK], 0 );
  end;
  //edModel.Text := sModelNumberOn;
  edSpringRevExisting.Text := sSpringOn;
  
  sLimEqTo := inttostr( fEquip.iCurrentEquip );

  wgrdParts.Font.Size := fMain.iGridFontSize;
  wgrdParts.TitleFont.Size := fMain.iGridFontSize;

  //v5.04K limited to Owner/Plant IF it's FLP and they're limited!
  if fMain.bFLP and NOT fMain.bCanChangeOP then begin
    // FLP and user does NOT have full run of OP
    // limit to owner by default
    cbOwnerOnly.checked := True;
    cbOwnerOnly.enabled := False;
    sOwnerOn := fMain.sOwnerID;
    if fMain.bForcePlant then begin
      // limit to plant
      cbPlantOnly.checked := True;
      cbPlantOnly.enabled := False;
      sPlantOn := fMain.sPlantID;
    end;
  end;

  // crank the user field names (less crit & check list) to the labels
  FieldNamesToForm;

  // load the combo box for series... all the rest get loaded in "realtime"
  //  depending on the user's selections (starting with model series)
  try
    if dmMain.wqryTemp.active then
      MessageDLg( 'Something is wrong...wqryTemp is active?? contact support', mtInformation, [mbOK], 0 );
  except end;
  try
    if dmMain.wqryT1.active then
      MessageDLg( 'Something is wrong...wqryT1 is active?? contact support', mtInformation, [mbOK], 0 );
  except end;
  with dmMain.wqryT do try
    if active then begin
      MessageDLg( 'Something is wrong...wqryT is active?? contact support', mtInformation, [mbOK], 0 );
    end;
    active := false;
    sql.clear;
    sql.add( 'select distinct ModelSeries from RvSpringChart order by ModelSeries' );
    active := True;
    first;
    rzcbConsolSeries.Items.Clear;
    rzcbConsolSeries.items.add( '[All]' );
    while NOT EOF do begin
      rzcbConsolSeries.items.add( fieldByName( 'ModelSeries' ).asstring );
      next;
    end;
    active := False;
  except
      MessageDlg( 'Could NOT load model series? '+exception(exceptobject).message,
                  mtError, [mbOK], 0 );
  end;
  try
    if dmMain.wqryT.active then  begin
      dmMain.wqryT.active := False;
      messageDlg( 'Active error???', mterror, [mbok], 0 );
    end;
  except end;

  lIgnoreOnChange := False;

  if fMain.cbAltGridRowColor.checked then
    wgrdParts.PaintOptions.AlternatingRowColor := fMain.wgrdList.paintOptions.AlternatingRowColor;
end;

procedure TfSpringLookup.FormKeyPress(Sender: TObject; var Key: Char);
begin
  { make the enter behave like tab }
  if key = #13 then begin
    key := #0;
    { move to next item }
    SelectNext( ActiveControl as tWinControl, True, True );
  end;
end;

procedure TfSpringLookup.lbTitleClick(Sender: TObject);
var
 c: tColor;
begin
  try

    fEquip.ScrPrint( tForm( self ) );
  except
    { oops }
  end;
end;

procedure TfSpringLookup.sbPrintClick(Sender: TObject);
begin
  try
    try
      fSpringRep := tfSpringRep.Create( fSpringLookup );
      with fSpringRep do begin
        // use current query
        qr.dataset := wgrdParts.DataSource.DataSet;
        if rzpcSearch.TabIndex <= 1 then begin
        end;
        qr.ReportTitle := 'Spring "stuff"';//+edModel.text;
        qrlbTitle.caption := qr.ReportTitle;
        qrlbQuery.caption := '';

        { crank in the grid and have it generate the report }
        SetupDetails( wgrdParts );

        qr.Preview;
      end; // with fRep
    except
      { some kind of error, tell user }
      MessageDlg( 'Could NOT create Report form '+exception(exceptobject).message,
                  mtError, [mbOK], 0 );
    end;  // try
  finally
    fSpringRep.free;
  end;
end;

procedure TfSpringLookup.sbExcelClick(Sender: TObject);
begin
  if rzpcSearch.TabIndex <= 1 then begin
    MessageDlg( 'You cannot export the Consolidated list', mtError, [mbok], 0 );
    exit;
  end;

  try
    try
      fExcel := tfExcel.create( fSpringLookup );
      with fExcel do begin
        fExcel.qExcel := dmMain.wqryT;
        fExcel.wdbGridExcel := wgrdParts;        // grid for titles...
        fExcel.lbFor.caption := 'Springs ';//+edModel.text;
      end;
      fExcel.ShowModal;
    except
      { some kind of error, tell user }
      MessageDlg( 'Could NOT create form '+#13+exception(exceptobject).message, mtError, [mbOK], 0 );
    end;  // try
  finally
    fExcel.free;
  end;
end;

procedure TfSpringLookup.bbSearchClick(Sender: TObject);
var
  iIs, iCur: integer;
  iL: LongInt;
  s: string;
  sQuery, sQ1, sSpring, sModel: string;
  i: integer;
  bAnd, bAddUpper: boolean;

  procedure ColumnsForReverseLookup;
  begin
    with dmMain.wqryT do begin
      with fieldByName( 'SpringNumber' ) do begin
        displayLabel := fEquip.q.fieldByName( 'SpringNumber' ).DisplayLabel;
        Visible := True;
//        index := 0;
        DisplayWidth := 15;
      end;
      with fieldByName( 'SpringRangFrom' ) do begin
        displayLabel := fEquip.q.fieldByName( 'SpringRangFrom' ).DisplayLabel;
        Visible := True;
//        index := 0;
        DisplayWidth := 15;
      end;
      with fieldByName( 'SpringRangeTo' ) do begin
        displayLabel := fEquip.q.fieldByName( 'SpringRangeTo' ).DisplayLabel;
        Visible := True;
//        index := 0;
        DisplayWidth := 15;
      end;
      with fieldByName( 'SpringMat' ) do begin
        displayLabel := fEquip.q.fieldByName( 'SpringMat' ).DisplayLabel;
        Visible := True;
//        index := 0;
        DisplayWidth := 15;
      end;
      with fieldByName( 'ModelNumber' ) do begin
        displayLabel := fEquip.q.fieldByName( 'ModelNumber' ).DisplayLabel;
        Visible := True;
//        index := 0;
        DisplayWidth := 15;
      end;
      with fieldByName( 'Manufacturer' ) do begin
        displayLabel := fEquip.q.fieldByName( 'Manufacturer' ).DisplayLabel;
        Visible := True;
//        index := 0;
        DisplayWidth := 15;
      end;
      with fieldByName( 'Service' ) do begin
        displayLabel := fEquip.q.fieldByName( 'Service' ).DisplayLabel;
        Visible := True;
//        index := 0;
        DisplayWidth := 15;
      end;
      with fieldByName( 'InletSize' ) do begin
        displayLabel := fEquip.q.fieldByName( 'INLETSIZE' ).DisplayLabel;
        Visible := True;
//        index := 0;
        DisplayWidth := 15;
      end;
      with fieldByName( 'CodeStamp' ) do begin
        displayLabel := fEquip.q.fieldByName( 'CodeStamp' ).DisplayLabel;
        Visible := True;
//        index := 0;
        DisplayWidth := 15;
      end;
      with fieldByName( 'NamePlateCapacity' ) do begin
        displayLabel := fEquip.q.fieldByName( 'NamePlateCapacity' ).DisplayLabel;
        Visible := True;
//        index := 0;
        DisplayWidth := 15;
      end;
      with fieldByName( 'NameCapUnit' ) do begin
        displayLabel := fEquip.q.fieldByName( 'NameCapUnit' ).DisplayLabel;
        Visible := True;
//        index := 0;
        DisplayWidth := 15;
      end;
      with fieldByName( 'SetPressure' ) do begin
        displayLabel := fEquip.q.fieldByName( 'SetPressure' ).DisplayLabel;
        Visible := True;
//        index := 0;
        DisplayWidth := 15;
      end;
      with fieldByName( 'ColdDiffSet' ) do begin
        displayLabel := fEquip.q.fieldByName( 'ColdDiffSet' ).DisplayLabel;
        Visible := True;
//        index := 0;
        DisplayWidth := 15;
      end;
      with fieldByName( 'SetPressUnit' ) do begin
        displayLabel := fEquip.q.fieldByName( 'SetPressUnit' ).DisplayLabel;
        Visible := True;
//        index := 0;
        DisplayWidth := 15;
      end;
      with fieldByName( 'OperatingTemp' ) do begin
        displayLabel := fEquip.q.fieldByName( 'OperatingTemp' ).DisplayLabel;
        Visible := True;
//        index := 0;
        DisplayWidth := 15;
      end;
      with fieldByName( 'Style' ) do begin
        displayLabel := fEquip.q.fieldByName( 'Style' ).DisplayLabel;
        Visible := True;
//        index := 0;
        DisplayWidth := 15;
      end;
      with fieldByName( 'CapType' ) do begin
        displayLabel := fEquip.q.fieldByName( 'CapType' ).DisplayLabel;
        Visible := True;
//        index := 0;
        DisplayWidth := 15;
      end;
      with fieldByName( 'ORIFDESIGNATION' ) do begin
        displayLabel := fEquip.q.fieldByName( 'ORIFDESIGNATION' ).DisplayLabel;
        Visible := True;
//        index := 0;
        DisplayWidth := 15;
      end;
      with fieldByName( 'SoftSeatMat' ) do begin
        displayLabel := fEquip.q.fieldByName( 'SoftSeatMat' ).DisplayLabel;
        Visible := True;
//        index := 0;
        DisplayWidth := 15;
      end;
    end; // with query
  end;
begin
  iCur := screen.cursor;
  try
    // setup a query, etc. etc.
    with dmMain.wqryT do begin
      active := False;
{$IFDEF ISPARADOX}
      RequestLive := False;
      UniDirectional := False;
      Constrained := False;
{$ENDIF}
{$IFDEF ISKINTERBASE}
      RequestLive := False;
      UniDirectional := False;
{$ENDIF}
      sql.clear;
      s := ''; sQuery := ''; sQ1 := '';

      SQL.add( 'Select E.UniqueKey, E.EquipmentKey, E.OwnerKey, E.PlantKey,' );
      sql.Add( 'E.SpringNumber, E.SpringRangFrom, E.SpringRangeTo, E.SpringMat,');
      SQL.add( 'E.ModelNumber, E.Manufacturer, E.Service, E.INLETSIZE, E.CodeStamp, E.NamePlateCapacity,' );
      sql.Add( 'E.NameCapUnit, E.SetPressure, E.ColdDiffSet, E.SetPressUnit, E.OperatingTemp,');
      sql.Add( 'E.Style, E.CapType, E.ORIFDESIGNATION, E.SoftSeatMat');

      sql.add( 'from '+fEquip.ReturnTableName+' E');
      sql.Add( 'where');
      sql.add( 'E.MostRecent='+quotedstr('T') );
      bAnd := true;

      if CBExcludeBlankSprings.checked then begin
        sql.Add( 'and');
        sql.add( 'not( (E.SpringNumber='+quotedstr('')+') or (E.SpringNumber is null) )' );
      end;

      // add in the spring number to find
      sSpring := uppercase( trim( edSpringRevExisting.text ) );
      if (sSpring <> '') and (rzpcSearch.TabIndex = 3) then begin
        // we're on the reverse existing tab
        sql.Add( 'and');

        case rgHowRevExisting.itemIndex of
        0: begin // Found anywhere inside
            // containing is already case-insensitive, no need for upper()
           sql.add( 'E.SpringNumber containing '+quotedstr( sSpring ));
           bAnd := True;
           end;
        1: begin  // starts with
           sql.add( 'E.SpringNumber like '+quotedstr( sSpring+'%' ));
           bAnd := True;
           end;
        else
          // equals
          sql.add( 'E.SpringNumber = '+quotedstr( sSpring ));
          bAnd := True;
        end;
      end;  //sSpring <> ''

      // always have to be aware of FLP limits
      if cbPlantOnly.checked then begin
        //v5.04K addition IF using plant FORCE use owner incase sPlantOn = ''

        // at some point, i (in code) set the .checked and it causes thia
        //  event to fire again... which redoes the "search" which causes grief
        //  SO, i mess with lIgnoreOnChange to prevent this
        //  it occurs because i allow real-time checking of the "owner" and "plant"
        //   filters; and they immediately change the SQL (ie. fire bbSearch.click)
        lIgnoreOnChange := True;
        cbOwnerOnly.checked := true;
        lIgnoreOnChange := False;
      end;

      if cbOwnerOnly.checked and (sOwnerOn <> '') then begin
        sql.add( 'and' );
        sql.add( 'E.OwnerKey='+quotedStr(sOwnerOn) );
      end;
      if cbPlantOnly.checked and (sPlantOn <> '') then begin
        sql.add( 'and' );
        sql.add( 'E.PlantKey='+quotedStr(sPlantOn) );
      end;

      if rzpcSearch.tabindex = 2 then begin
        // other kinds of limits for the "existing spring data lookup"?
        if trim(edSpringRevExistingMfg.text) <> '' then begin
          sql.add( 'and' );
          sql.add( 'E.Manufacturer containing '+quotedstr( trim(edSpringRevExistingMfg.text) ));
        end;
        if trim(edSpringRevExistingService.text) <> '' then begin
          sql.add( 'and' );
          sql.add( 'E.Service containing '+quotedstr( trim(edSpringRevExistingService.text) ));
        end;
        if trim(edSpringRevExistingModel.text) <> '' then begin
          sql.add( 'and' );
          sql.add( 'upper(E.ModelNumber) like '+quotedstr( uppercase(trim(edSpringRevExistingModel.text)+'%') ));
        end;
        if trim(edSpringRevExistingOrifice.text) <> '' then begin
          sql.add( 'and' );
          sql.add( 'upper(E.ORIFDESIGNATION) containing '+quotedstr( uppercase(trim(edSpringRevExistingOrifice.text)) ));
        end;
        if trim(edSpringRevExistingInlet.text) <> '' then begin
          sql.add( 'and' );
          sql.add( 'upper(E.INLETSIZE) like '+quotedstr( uppercase(trim(edSpringRevExistingInlet.text)+'%') ));
        end;

        if edSpringRevExistingSet.IntValue <> 0 then begin
          sql.add( 'and' );
          sql.add( '(E.ColdDiffSet  between '+floattostr(dPress-edSpringRevExistingSet.IntValue)+' and '+floattostr(dPress+edSpringRevExistingSet.IntValue) );
          sql.add( 'or' );
          sql.add( 'E.SetPressure  between '+floattostr(dPress-edSpringRevExistingSet.IntValue)+' and '+floattostr(dPress+edSpringRevExistingSet.IntValue)+')' );
        end;
      end; // look up springs in existing data (tab = 2)


      // add in the sort by
      sql.add( 'order by' );
      // will change to column header clicked = sort by
      sSortingByAlready := 'upper( E.SpringNumber )';
      sql.add( sSortingByAlready );


      //added build query into string incase we need it for error
      sQuery := '';
      try
        for i := 0 to dmMain.wqryT.SQL.Count-1 do
          sQuery := sQuery + dmMain.wqryT.SQL[i]+#13#10;
      except end;

      // enough, execute the query
      screen.Cursor := crHourGlass;
      active := True;

      // turn on the required columns:
      dmMain.wqryT.DisableControls;
      for i := 0 to dmMain.wqryT.FieldCount-1 do
        dmMain.wqryT.Fields[i].Visible := False;

      ColumnsForReverseLookup;
      dmMain.wqryT.EnableControls;
    end; // with

{$IFDEF ISPARADOX}
    iL := dmMain.wqryT.RecordCount;
{$ENDIF}
{$IFDEF ISKINTERBASE}
    iL := dmMain.wqryT.RecordCountAll;
{$ENDIF}
    lbCount.caption := inttostr( iL );

    //open owner/plant queries
    OpenOP;
  except
    MessageDlg( 'General open error'+#13+exception(exceptobject).message,
                mtError, [mbOK], 0 );

    //v5.1K added pop up query too
    MessageDlg( 'SQL:'+#13#10+#13#10+sQuery, mtInformation, [mbOK], 0 );
  end;
  screen.cursor := iCur;

  if dmMain.wqryT.active then begin
    rzpanResults.visible := True;
    sbSQL.Visible := True;
    SaveGridCols;
  end;
end;

procedure TfSpringLookup.OpenOP;
begin
    // open the owner and plant tables for lookup
    with dmMain.wqryTemp do try
      active := False;
{$IFDEF ISPARADOX}
      ParamCheck := False;
      RequestLive := False;
      UniDirectional := False;
      Constrained := False;
{$ENDIF}
{$IFDEF ISKINTERBASE}
      RequestLive := False;
      UniDirectional := False;
{$ENDIF}
      sql.clear;
      sql.add( 'Select * from Owners O' );
      sql.add( 'order by upper(O.OwnerName)'); //5.15dK added upper()
      Active := True;
    except
      MessageDlg( 'Could not open Owners'+#13+exception(exceptobject).message,
                  mtError, [mbOK], 0 );
    end;
    with dmMain.wqryT1 do try
      active := False;
{$IFDEF ISPARADOX}
      ParamCheck := False;
      RequestLive := False;
      UniDirectional := False;
      Constrained := False;
{$ENDIF}
{$IFDEF ISKINTERBASE}
      RequestLive := False;
      UniDirectional := False;
{$ENDIF}
      sql.clear;
      sql.add( 'Select * from Plants P' );
      sql.add( 'order by upper(P.Location)'); //v5.15dK added upper()
      Active := True;
    except
      MessageDlg( 'Could not open Plants'+#13+exception(exceptobject).message,
              mtError, [mbOK], 0 );
    end;
end;

procedure TfSpringLookup.FormDestroy(Sender: TObject);
begin
  // close the owner / plant tables
  try
    dmMain.wqryTemp.Close;
  except end;
  try
    dmMain.wqryT1.Close;
  except end;
  try
    dmMain.wqryT.Close;
    dmMain.wqryT.sql.clear;
  except end;
  try
    dmMain.wqryRVSpringChart.close;
  except end;
  try
    dmMain.Query2.close;
  except end;
end;

procedure TfSpringLookup.wgrdPartsRowChanged(Sender: TObject);
// get new O/P
begin
  if bInTransfer then
    exit;

  if (rzpcSearch.tabindex <= 1) or (dmMain.wqryT.active = False) then
    if dmMain.wqryT.findfield( 'OwnerKey' ) = nil then begin
    // ok, this is consolidated lookup, nothing to do with repair data
    //
    // sometimes when we're switching tabs, in the OnCHanging of the tab control
    //  it messes with this grid causing this event to fire SO make sure it doesn't
    //  error out because the .tabIndex isn't set yet (ie. it's in the process
    //  of changing tabs SO the .TabIndex isn't proper yet)
    lbO.caption := '"unused for Consolidated chart lookup"';
    lbP.caption := lbO.caption;
    exit;
  end;

  lbO.caption := '(unknown)';
  lbP.caption := lbO.caption;
  if (dmMain.wqryT1.Active <> True) OR (dmMain.wqryTemp.active <> True) then begin
    exit;
  end;

  try
    //v5.01K sUK := dmMain.wqryT.fieldByName( 'UniqueKey' ).AsString; gives me the part unique key
    // looked at order of fields in SQL select it's P.* THEN E.(fields) SO to get the
    // E.UniqueKey, I need the 2nd UniqueKey in the query OR UniqueKey_1.  But, incase
    // that ever stops working because of SQL change, I'll just use the equipment
    // uniquekey from the parts table which is in RepairEntryKey
    sUK := dmMain.wqryT.fieldByName( 'UniqueKey' ).AsString;
    sEK := dmMain.wqryT.fieldByName( 'EquipmentKey' ).AsString;
    sOK := dmMain.wqryT.fieldByName( 'OwnerKey' ).AsString;
    sPK := dmMain.wqryT.fieldByName( 'PlantKey' ).AsString;
    with dmMain.wqryTemp do begin
      first;
      //v5.1K there is a very very weird case where FB doesn't "locate" even though
      //      it should BUT if we do the locate twice...it works perfect?
      //      I REALLY DON'T LIKE THAT GLITCH?!?! it's in Av2MoveOwner.pas too
      //      search for "I REALLY DON'T" there
      // SO...i changed the locate's (and more code below) so they would work properly
      application.processMessages;
      locate( 'UniqueKey', sOK, [] );
      application.processMessages;
      locate( 'UniqueKey', sOK, [] );
      lbO.caption := FieldByName( 'OwnerName' ).AsString;
      sInfo[0] := lbO.caption; // owner name
    end;
    with dmMain.wqryT1 do begin
      first;
      //v5.1K changed "locate" code below
      locate( 'UniqueKey', sPK, [] );
      application.processMessages;
      locate( 'UniqueKey', sPK, [] );
      lbP.caption := FieldByName( 'Location' ).AsString+' | '+FieldByName( 'Area' ).AsString;
      sInfo[1] := FieldByName( 'Location' ).AsString; // plant location
      sInfo[2] := FieldByName( 'Area' ).AsString;  // plant area
      sInfo[3] := FieldByName( 'Account' ).AsString;  // plant account
      sInfo[4] := FieldByName( 'Universal' ).AsString;  // plant universal
      sInfo[5] := FieldByName( 'Notes' ).AsString;  // plant notes //v5.01K added
      sInfo[10] := FieldByName( 'RVREPAIRPROC' ).AsString;
      sInfo[11] := FieldByName( 'CVREPAIRPROC' ).AsString;
      sInfo[12] := FieldByName( 'MOVREPAIRPROC' ).AsString;
      sInfo[13] := FieldByName( 'LVREPAIRPROC' ).AsString;
    end;
  except
    MessageDlg( 'Could not get O/P'+#13+exception(exceptobject).message,
                mtError, [mbOK], 0 );
  end;
end;

procedure TfSpringLookup.cbFreezeColumnsClick(Sender: TObject);
begin
  if cbFreezeColumns.checked then
    wgrdParts.fixedCols := 3
  else
    wgrdParts.fixedCols := 0;
end;

procedure TfSpringLookup.sbSQLClick(Sender: TObject);
var
  s: string;
  i: integer;
begin
  s := '';
  try
    for i := 0 to TIBOQuery(wgrdParts.datasource.dataset).SQL.Count-1 do
      s := s + TIBOQuery(wgrdParts.datasource.dataset).SQL[i]+#13#10;
  except end;
  MessageDlg( 'SQL:'+wgrdparts.DataSource.DataSet.Name+ #13#10+#13#10+s, mtInformation, [mbOK], 0 );
  s := '';
  try
    for i := 0 to dmMain.Query2.SQL.Count-1 do
      s := s + dmMain.Query2.SQL[i]+#13#10;
  except end;
  MessageDlg( 'SQL:'+dmMain.Query2.Name+ #13#10+#13#10+s, mtInformation, [mbOK], 0 );
  s := '';
  try
    for i := 0 to dmMain.wqryT.SQL.Count-1 do
      s := s + dmMain.wqryT.SQL[i]+#13#10;
  except end;
  MessageDlg( 'SQL:'+dmMain.wqryT.Name+ #13#10+#13#10+s, mtInformation, [mbOK], 0 );
end;

procedure TfSpringLookup.SetDS( iType: integer );
// sets the data source for all items to either:
// iType 0=read only (fMain.wqryRVD, fMain.wdsRVD)
//       1=edit (fMain.wqryEdit, fMain.wdsEdit
var
  c: tComponent;
  i: integer;
begin
  // make sure global guy knows
  if iType = 0 then
    ds := dmMain.wdsRVD
  else
    ds := dmMain.wdsEdit;

  ds.DataSet.DisableControls;

  // change all the data-aware components on the form
  for i := 0 to ComponentCount-1 do begin
    c := Components[i];
    if c is tDBText then
      tDBText(c).DataSource := ds;
  end; // for
  ds.DataSet.EnableControls;
end;

procedure TfSpringLookup.FieldNamesToForm;
// places the users field names from the AvFields[] into the labels on any page
//   for the relief details form only!!!!
// does not include crit dims and qc stuff
var
  i, iField: integer;
  l: tLabel;
  c: tComponent;
begin
  for i := 0 to ComponentCount-1 do begin
    c := Components[i];
    if c is tLabel then begin
      l := tLabel( c );
      if (l.tag>1000000) and (l.tag<2000000) then begin
        // it's a user field, plug in it's correct user label
        iField := l.tag - 1000000-1; // field number
        l.caption := fMain.AvFields[iField].UseName;
      end;
    end; // if c

    // tabsheets too v4.00
    if c is tTabSheet then begin
      if (c.tag>1000000) and (c.tag<2000000) then begin
        // it's a user field, plug in it's correct user label
        iField := c.tag - 1000000-1; // field number
        tTabSheet(c).caption := fMain.AvFields[iField].UseName;
      end;
    end; // if c

    //v4.26 for the changes in forms
    if c is tDBCheckBox then begin
      if (c.tag>1000000) and (c.tag<2000000) then begin
        // it's a user field, plug in it's correct user label
        iField := c.tag - 1000000-1; // field number
        tdbCheckBox( c ).caption := fMain.AvFields[iField].UseName;
      end;
    end; // if c

  end;  // for
end;

procedure TfSpringLookup.wgrdPartsTitleButtonClick(Sender: TObject; AFieldName: String);
//added ability to sort by title column clicking...
var
  i, iOrder: integer;
  s, sUpper1, sUpper2: string;
  bFloat: boolean;
  psSortBy, psDesc, psSortingByAlready: ^string;  // pointers for these common strings
begin
  // by defualt, we'll use the "Consolidated lookup" (ie. RVSPringChart query) fields
  psSortBy := @sSortByCL;
  psDesc := @sDescCL;
  psSortingByAlready := @sSortingByAlreadyCL;
  if rzpcSearch.tabindex >= 2 then begin
    // we want the strings that are for wqryT's SQL
    psSortBy := @sSortBy;
    psDesc := @sDesc;
    psSortingByAlready := @sSortingByAlready;
  end;

  if (wgrdParts.datasource.dataset.active = False) or (trim(aFieldName) = '') then
    exit;

  with TIBOQuery(wgrdParts.datasource.dataset) do try
    // took this OUT in 5.15g NOT sure why it's here?
    //if NOT ( (FieldByName( aFieldName ) is tFloatField) or (FieldByName( aFieldName ) is tStringField) ) then begin
    //  // only sort string and float fields
    //  messageDlg( 'can only sort string fields (for now)', mtInformation, [mbok], 0 );
    //  exit;
    //end;

    bFloat := false;
    if (FieldByName( aFieldName ) is tFloatField) or (FieldByName( aFieldName ) is tIntegerField) then
      bFloat := True;

    iOrder := -1;
    for i := 0 to sql.count-1 do begin
      if (uppercase(sql[i]) = 'ORDER BY') or (uppercase(sql[i]) = 'ORDER  BY') then begin
        iOrder := i+1;
        break;
      end;
    end;

    if (iOrder = -1) or (iOrder >= sql.Count) then begin
      // huh? order by without anything after it???
      messageDLg( 'EXITING: Order by clause found at '+inttostr( iOrder)+ '  max = '+inttostr( sql.count), mtError, [mbok], 0 );
      s := '';
      for i := 0 to TIBOQuery(wgrdParts.datasource.dataset).sql.count-1 do
        s := s + TIBOQuery(wgrdParts.datasource.dataset).sql[i]+#13#10;
      MessageDlg( 'query'+#13+s, mtError, [mbOK], 0 );
      exit;
    end;

    active := False;

    if uppercase( aFieldName ) = uppercase( psSortBy^ ) then begin
      // already sorting by the field, just change it's descending...
      if psDesc^ = '' then
        psDesc^ := ' DESC'
      else
        psDesc^ := '';
    end;
    psSortBy^ := aFieldName;

    sUpper1 := 'upper('; sUpper2 := ')';
    if (pos( 'DATE', uppercase( aFieldName ) ) <> 0) or (uppercase(aFieldName) = 'MODELNUMBER')
       or (uppercase(aFieldName) = 'TAGNUMBER') or (bFloat) then begin
      // some fields, we do NOT want to upper()...
      sUpper1 := ''; sUpper2 := '';
    end;

    sql[iOrder] := sUpper1+'E.'+psSortBy^+sUpper2+psDesc^+', '+psSortingByAlready^;

    active := True;

    // lastly, re-"visible" the proper fields... this active = true turned them
    //   all back to visible
    dmMain.wqryT.DisableControls;

    if rzpcSearch.tabindex >= 2 then begin
      // for the "reverse lookup"
      for i := 0 to dmMain.wqryT.FieldCount-1 do
        dmMain.wqryT.Fields[i].Visible := False;

      try
        for i := 0 to lbGridCols.Items.Count-1 do begin
        //lbGridCols.Items.AddObject( wgrdList.Columns[i].FieldName+'|||'+wgrdList.Columns[i].DisplayLabel,
        //                             tObject(wgrdList.ColWidths[i]) );

        iOrder := pos( '|||', lbGridCols.items[i] );
        sUpper1 := copy( lbGridCols.items[i], 1, iOrder-1 );  //fieldname
        sUpper2 := copy( lbGridCols.items[i], iOrder+3, 999 ); //display label

        iOrder := integer( lbGridCols.Items.Objects[i] ); // display width

        //messageDlg( inttostr(i)+'  '+supper1+' '+supper2+' '+inttostr( iorder)+' '+inttostr( lbGridCols.Items.Count-1), mtInformation, [mbOK], 0 );
        with dmMain.wqryT.fieldByName( sUpper1 ) do begin
          displayWIdth := iOrder;
          visible := True;
          index := i;
          displayLabel := sUpper2;
        end;
        end;

        //messageDlg( 'enable', mtInformation, [mbOK], 0 );
      except
        MessageDlg( 'Could not set display columns??? '+#13+exception(exceptobject).message,
                    mtError, [mbOK], 0 );
      end;
    end;  // tabIndex = 2  (reverse lookup on all)

    dmMain.wqryT.EnableControls;

  except
    s := exception(exceptobject).message+#13#10+#13#10;
    for i := 0 to TIBOQuery(wgrdParts.datasource.dataset).sql.count-1 do
      s := s + TIBOQuery(wgrdParts.datasource.dataset).sql[i]+#13#10;
    MessageDlg( 'Could NOT open '+aFieldName+#13#10+s, mtError, [mbOK], 0 );
  end;
end;

procedure TfSpringLookup.SaveGridCols;
// i need to be
//        able to reset the visible fields for grid
//        store the visible fields in an invisible list box
var
  i, iCols, iWidth: integer;
begin
  try
    lbGridCols.items.clear;
    iCols := wgrdParts.GetColCount;
    for i := 0 to iCols-1 do begin
      if wgrdParts.Columns[i].FieldName <> '' then begin
        // what?? the GetColCount is WRONG????
        iWidth := dmMain.wqryT.fieldByName( wgrdParts.Columns[i].FieldName ).DisplayWidth;
        //messageDlg( inttostr(wgrdList.ColWidths[i])+' '+inttostr( iWidth)+wgrdList.Columns[i].FieldName+'|||'+wgrdList.Columns[i].DisplayLabel, mtInformation, [mbok], 0 );
        lbGridCols.Items.AddObject( wgrdParts.Columns[i].FieldName+'|||'+wgrdParts.Columns[i].DisplayLabel,
                                     tObject(iWidth) );
      end;
    end;
  except
    MessageDlg( 'Could not get display columns??? '+#13+exception(exceptobject).message,
                mtError, [mbOK], 0 );
  end;
end;

procedure TfSpringLookup.rzpcSearchChanging(Sender: TObject;
  NewIndex: Integer; var AllowChange: Boolean);
var
  s: string;
  i: integer;
begin
  if (tsConLookup.enabled = False) and (newindex<=1) then begin
    allowchange := False;
    exit;
  end;
    
  bReverseConsol := False;
  with dmMain.Query2 do begin
    active := False;
    if newIndex = 1 then begin
      // reverse consolidated lookup
      bReverseConsol := True;

      // get the unique springs in the consolidated table
      //  and count of them so gtc can use to see how
      //  many valves a spring is used in
      sql.clear;
      sql.add( 'SELECT springmarking , COUNT(*) AS num_times FROM rvspringchart' );
      sql.add( 'where SpringMarking<>'+quotedstr('CF'));
      sql.add( 'GROUP BY springmarking' );
      sql.add( 'order by num_times desc' );
      active := True;
      fieldbyName('springmarking').DisplayLabel := 'Spring Number';
    end;

    if newIndex = 3 then begin
      // reverse existing lookup lookup

      // get the unique springs and count of them from relief data so gtc can use to see how
      //  many valves a spring is used in
      sql.clear;
      sql.add( 'SELECT springnumber, manufacturer, COUNT(*) AS num_times FROM reliefd' );
      sql.add( 'where not( ( springnumber='+quotedstr('')+') or (springnumber is null) )' );
      sql.add( 'and MostRecent='+quotedstr('T') );
      if cbOwnerOnly.checked and (sOwnerOn <> '') then begin
        sql.add( 'and' );
        sql.add( 'OwnerKey='+quotedStr(sOwnerOn) );
      end;
      if cbPlantOnly.checked and (sPlantOn <> '') then begin
        sql.add( 'and' );
        sql.add( 'PlantKey='+quotedStr(sPlantOn) );
      end;

      sql.add( 'GROUP BY springnumber, manufacturer' );
      if cbSortCount.Checked then
        sql.add( 'order by num_times desc, manufacturer, springnumber' )
      else
        sql.add( 'order by manufacturer, springnumber, num_times desc' );
      try
        s := '';
        for i := 0 to sql.count-1 do
          s := s+sql[i]+#13#10;
        active := True;
      except
        MessageDlg( 'freq SQL??? '+#13#10+s+#13+exception(exceptobject).message,
                mtError, [mbOK], 0 );
      end;
      fieldbyName('Manufacturer').DisplayLabel := fEquip.q.fieldByName( 'Manufacturer' ).DisplayLabel;
      fieldbyName('springnumber').DisplayLabel := fEquip.q.fieldByName( 'springnumber' ).DisplayLabel;
    end;
  end;

  try
    // do what we need when tabs switch
    if rzpcSearch.TabIndex >= 2 then begin
      // leaving the "existing springs - reverse" do what we need
      SaveGridCols;
    end;
    dmMain.wqryT.active := False;
    dmMain.wqryRVSpringChart.active := False;
  except
    MessageDlg( 'Could not get display columns??? '+#13+exception(exceptobject).message,
                mtError, [mbOK], 0 );
  end;

  AllowChange := True;
  rzPanSearch.visible := False;

  if wgrdParts.DataSource <> dmMain.wdsRVSpringChart then
    wgrdParts.DataSource := dmMain.wdsRVSpringChart;

  if newIndex >= 2 then begin
    // going TO "existing springs - reverse" do what we need
    rzPanSearch.visible := True;
    if wgrdParts.DataSource <> dmMain.dsT then
      wgrdParts.DataSource := dmMain.dsT;
  end;

  if newIndex = 0 then begin
    if rzcbConsolSeries.ItemIndex > 0 then
      // there is something being looked up, re-look-it-up
      OpenConsolLookup;
  end;
end;

procedure TfSpringLookup.rzcbConsolSeriesChange(Sender: TObject);
begin
  if lIgnoreOnChange then
    // building the list in OnCreate
    exit;

  rzcbOrifice.items.Clear;
  rzcbInletSize.items.Clear;
  rzcbService.items.Clear;
  rzcbTempClass.items.Clear;

  OpenConsolLookup;

  if dmMain.wqryRVSpringChart.active then begin
    if (dmMain.wqryRVSpringChart.RecordCountAll = 0) and (cbOring.ItemIndex <> 0 ) then begin
      MessageDlg( 'Your current selection resulted in ZERO springs.'+#13#10+#13#10+
                  'Thus, changing to "ALL" O-Ring option... BE AWARE', mtInformation, [mbok], 0 );
      cbOring.itemIndex := 0;
    end;
  end;
end;

procedure TfSpringLookup.AddConsolModelSeries( tsl: tStrings );
begin
  // there's a ton of "CF" springmarking records... that's
  //  "consult factory" clearly NOT what i'm interested in displaying
      if bAnd then
        tsl.Add( 'and')
      else
        tsl.Add( 'where');
      bAnd := True;
      tsl.add( 'E.SpringMarking<>'+quotedstr('CF') );

      if rzcbConsolSeries.ItemIndex > 0 then begin
        if bAnd then
          tsl.Add( 'and')
        else
          tsl.Add( 'where');
        bAnd := True;
        tsl.add( 'E.ModelSeries ='+quotedstr(rzcbConsolSeries.Text) );
      end;

      //oring
      if cbORing.itemindex <> 0 then begin
        if bAnd then
          tsl.Add( 'and')
        else
          tsl.Add( 'where');
        bAnd := True;
        if cbORing.itemindex = 1 then
          tsl.add( 'upper(E.Option2) Like '+quotedstr('Y%') )
        else
          // need the "-" or null ones too!!!
          tsl.add( 'upper(E.Option2) not Like '+quotedstr('Y%') );
      end;

      //UM
      if cbUM.itemindex <> 0 then begin
        if bAnd then
          tsl.Add( 'and')
        else
          tsl.Add( 'where');
        bAnd := True;
        if cbUM.itemindex = 1 then
          tsl.add( 'E.Bool1 = '+quotedstr('T') )
        else
          tsl.add( 'E.Bool1 = '+quotedstr('F') );
      end;
end;

procedure TfSpringLookup.AddConsolPressure( tsl: tStrings );
begin
      if cbConsolidatedLookupMeetsPressure.checked then begin
        if bAnd then
          tsl.Add( 'and')
        else
          tsl.Add( 'where');
        bAnd := True;
        tsl.add( '( (E.EI1 <='+formatFloat( '0', dPress)+') and (E.EI2>='+formatFloat( '0', dPress)+') )' );
      end;
end;

procedure TfSpringLookup.AddConsolInlet( tsl: tStrings );
begin
      if rzcbInletSize.ItemIndex > 0 then begin
        if bAnd then
          tsl.Add( 'and')
        else
          tsl.Add( 'where');
        bAnd := True;
        tsl.add( 'E.InletSize ='+quotedstr(rzcbInletSize.Text) );
      end;
end;

procedure TfSpringLookup.AddConsolOrifice( tsl: tStrings );
var
  s: string;
begin
      if rzcbOrifice.ItemIndex > 0 then begin
        if bAnd then
          tsl.Add( 'and')
        else
          tsl.Add( 'where');
        bAnd := True;

        s := trim( rzcbOrifice.Text );
        
        // see procedure TdmMain.wqryRVSpringChartORIFICEGetText() for details
        if s = '1 (.096)' then
          s := '1';
        if s = '2 (.110)' then
          s := '2';
        if s = '3 (.126)' then
          s := '3';
        if s = '4 (.226)' then
          s := '4';
        if s = '5 (.357)' then
          s := '5';
        if s = '6 (.567)' then
          s := '6';

        tsl.add( 'E.Orifice ='+quotedstr(s) );
      end;
end;

procedure TfSpringLookup.AddConsolTempClass( tsl: tStrings );
begin
      if rzcbTempClass.ItemIndex > 0 then begin
        if bAnd then
          tsl.Add( 'and')
        else
          tsl.Add( 'where');
        bAnd := True;
        tsl.add( 'E.TempClassLetters ='+quotedstr(rzcbTempClass.Text) );
      end;
end;

procedure TfSpringLookup.AddConsolService( tsl: tStrings );
begin
      if rzcbService.ItemIndex > 0 then begin
        if bAnd then
          tsl.Add( 'and')
        else
          tsl.Add( 'where');
        bAnd := True;
        tsl.add( 'E.Service ='+quotedstr(rzcbService.Text) );
      end;
end;

procedure TfSpringLookup.OpenConsolLookup;
// using all the settings on the consolidated lookup tab, get springs
var
  sUpper1, sUpper2, s, sQ1, sQuery, sSpring: string;
  i, iCur: integer;
  bFloat: boolean;
begin
//    sSortByCL, sDescCL, sSortingByAlreadyCL: string;
  iCur := screen.cursor;
  bAnd := False;
  bFloat := False;
  try
    // setup a query, etc. etc.
    with dmMain.wqryRVSpringChart do begin
      // is it already open?
      if active = True then begin
        // yes, see if the user has clicked a column header to sort by
        if sSortByCL <> '' then begin
          // they have...is it a float field?
          if fieldByName( sSortByCL ) is tFloatField then
            bFloat := True
          else
            bFloat := false;
        end;
      end;

      active := False;
{$IFDEF ISPARADOX}
      RequestLive := False;
      UniDirectional := False;
      Constrained := False;
{$ENDIF}
{$IFDEF ISKINTERBASE}
      RequestLive := False;
      UniDirectional := False;
{$ENDIF}
      sql.clear;
      s := ''; sQuery := ''; sQ1 := '';

      SQL.add( 'Select E.*' );

      sql.add( 'from RvSpringChart E');
      bAnd := False;

      if bReverseConsol = False then begin
        // get these "where" clauses OUT of the source so i can reuse them
        AddConsolModelSeries( sql );

        AddConsolPressure( sql );
        AddConsolInlet( sql );
        AddConsolOrifice( sql );
        AddConsolTempClass( sql );
        AddConsolService( sql );
      end
      else begin
        // consol reverse lookup
        sSpring := uppercase( trim( edConSolReverse.text ) );
        if sSpring <> '' then begin
          sql.Add( 'where');

          case cbConSolReverse.itemIndex of
          0: begin // contains Found anywhere inside
              // containing is already case-insensitive, no need for upper()
             sql.add( 'E.springmarking containing '+quotedstr( sSpring ));
             bAnd := True;
             end;
          1: begin  // starts with
             sql.add( 'E.springmarking like '+quotedstr( sSpring+'%' ));
             bAnd := True;
             end;
          else
            // equals
            sql.add( 'E.springmarking = '+quotedstr( sSpring ));
            bAnd := True;
          end;
        end;  //sSpring <> ''
      end;

      // add in the sort by
      sql.add( 'order by' );
      // will change to column header clicked = sort by
      // series, orifice, inlet, pressure from
      sSortingByAlreadyCL := 'E.ModelSeries, E.Orifice, E.Service, E.InletSize, E.EI1';

      sUpper1 := 'upper('; sUpper2 := ')';
      if (pos( 'DATE', uppercase( sSortByCL ) ) <> 0) or (uppercase(sSortByCL) = 'MODELNUMBER')
         or (uppercase(sSortByCL) = 'TAGNUMBER') or (bFloat) then begin
        // some fields, we do NOT want to upper()...
        sUpper1 := ''; sUpper2 := '';
      end;

      if sSortByCL <> '' then
        sql.add( sUpper1+'E.'+sSortByCL+sUpper2+sDescCL+', '+sSortingByAlreadyCL )
      else
        sql.add( sSortingByAlreadyCL );

      //added build query into string incase we need it for error
      sQuery := '';
      try
        for i := 0 to SQL.Count-1 do
          sQuery := sQuery + SQL[i]+#13#10;
      except end;

      screen.Cursor := crHourGlass;
      active := True;
      rzpanResults.visible := True;
      lbCount.caption := inttostr( recordCountAll );
    end; // with wqrySpringChart

  except
    messageDlg( 'Could not open Consolidated Chart Lookup...'+#13#10+
                exception(exceptobject).message+#13#10+#13#10+sQuery, mtError, [mbok], 0 );
  end;
  screen.Cursor := iCur;

  rzlbORing1900.Visible := False;
  if cbOring.Text = 'Yes' then
    if pos('1900', rzcbConsolSeries.Text ) > 0 then
      rzlbORing1900.Visible := True;
end;

procedure TfSpringLookup.FormShow(Sender: TObject);
var
  sORing: string;
begin
  if (rzcbConsolSeries.Items.count-1 = 0) or (bValvKeep = False)  then begin
    // the first option in the list is "[All]" thus the -1
    if fMain.bAlreadyWarnedNoSprings = false then
      MessageDlg( 'Consolidated Spring Charts NOT present, contact support.'+#13#10+#13#10+
                  'Other Spring Lookup functions still available.', mtInformation, [mbOK], 0);

    fMain.bAlreadyWarnedNoSprings := True;
    tsConLookup.enabled := False;
    tsConRLookup.enabled := False;
    rzpcSearch.TabIndex := 2;
  end;
  try
    dPress := -1.0;
    tryStrToFloat( dbTextCDTP.Caption, dPress );
    if dPress <= 0.0 then
      tryStrToFloat( dbTextSet.caption, dPress );
  except
    MessageDlg( 'dPress error??'+#13+exception(exceptobject).message, mtError, [mbOK], 0 );
    dPress := -2.0;
  end;

  // make some sensible best 'first guess' at the set press range required
  if dPress > 0.0 then
    edSpringRevExistingSet.IntValue := 10;
  if dPress > 100.0 then
    edSpringRevExistingSet.IntValue := 20;
  if dPress > 500.0 then
    edSpringRevExistingSet.IntValue := 30;

  // IF there's an oring material... then, change to "yes" for oring drop down
  sORing := uppercase( trim( dbtOring.Caption ) );
  if sORing <> '' then begin
    // there IS an oring material... just make sure it's valid
    if not( (sOring='-') or (sORing='NA') or (sORing='N/A') or (sORing='NO') or (sORing='NONE')
          ) then
      cbOring.ItemIndex := 1; // yes
  end;
end;

procedure TfSpringLookup.rzcbOrificeDropDown(Sender: TObject);
var
  i: integer;
  sText, sQuery: string;
begin
  if lIgnoreOnChange then
    // building the list in OnCreate
    exit;

  iOptionIndexWasB4DropDown := rzcbOrifice.ItemIndex;

  if rzcbConsolSeries.ItemIndex <=-1 then begin
    messageDlg( 'You MUST pick a "Model Series" first', mtError, [mbok], 0 );
    exit;
  end;

  with dmMain.wqryT do try
    if active then begin
      MessageDLg( 'Something is wrong...wqryT is active?? contact support', mtInformation, [mbOK], 0 );
    end;
    active := false;
    sql.clear;
    sql.add( 'select distinct E.Orifice from RvSpringChart E' );
    bAnd := False;
    AddConsolModelSeries( sql );

    // pressure matches??
    AddConsolPressure( sql );
    AddConsolInlet( sql );
    AddConsolTempClass( sql );
    AddConsolService( sql );

    //added build query into string incase we need it for error
    sQuery := '';
    try
      for i := 0 to SQL.Count-1 do
        sQuery := sQuery + SQL[i]+#13#10;
    except end;

    active := True;
    first;
    rzcbOrifice.Items.Clear;
    rzcbOrifice.items.add( '[All]' );
    while NOT EOF do begin
      // see procedure TdmMain.wqryRVSpringChartORIFICEGetText() for details
      sText := trim( fieldByName( 'Orifice' ).asString);
      if trim(rzcbConsolSeries.Text) = '19000'  then begin
        // only for 19000 series
        if stext = '1' then
          stext := '1 (.096)';
        if stext = '2' then
          stext := '2 (.110)';
        if stext = '3' then
          stext := '3 (.126)';
        if stext = '4' then
          stext := '4 (.226)';
        if stext = '5' then
          stext := '5 (.357)';
        if stext = '6' then
          stext := '6 (.567)';
      end;
      rzcbOrifice.items.add( sText );

      next;
    end;
    active := False;
  except
      MessageDlg( 'Could NOT load orifice list? '+sQuery+#13#10+#13#10+exception(exceptobject).message,
                  mtError, [mbOK], 0 );
  end;
  try
    if dmMain.wqryT.active then  begin
      dmMain.wqryT.active := False;
      messageDlg( 'Active error???', mterror, [mbok], 0 );
    end;
  except end;
  rzcbOrifice.ItemIndex := iOptionIndexWasB4DropDown; // put it back
end;

procedure TfSpringLookup.rzcbOrificeChange(Sender: TObject);
begin
  if lIgnoreOnChange then
    // building the list in OnCreate
    exit;

  //rzcbInletSize.items.Clear;

  OpenConsolLookup;
end;

procedure TfSpringLookup.rzcbInletSizeDropDown(Sender: TObject);
var
  i: integer;
  sQuery: string;
begin
  if lIgnoreOnChange then
    // building the list in OnCreate
    exit;

  iOptionIndexWasB4DropDown := rzcbInletSize.ItemIndex;

  if rzcbConsolSeries.ItemIndex <=-1 then begin
    messageDlg( 'You MUST pick a "Model Series" first', mtError, [mbok], 0 );
    exit;
  end;

  with dmMain.wqryT do try
    if active then begin
      MessageDLg( 'Something is wrong...wqryT is active?? contact support', mtInformation, [mbOK], 0 );
    end;
    active := false;
    sql.clear;
    sql.add( 'select distinct E.InletSize from RvSpringChart E' );
    bAnd := False;
    AddConsolModelSeries( sql );

    // pressure matches??
    AddConsolPressure( sql );
    AddConsolOrifice( sql );
    AddConsolTempClass( sql );
    AddConsolService( sql );

    //added build query into string incase we need it for error
    sQuery := '';
    try
      for i := 0 to SQL.Count-1 do
        sQuery := sQuery + SQL[i]+#13#10;
    except end;

    active := True;
    first;
    rzcbInletSize.Items.Clear;
    rzcbInletSize.items.add( '[All]' );
    while NOT EOF do begin
      rzcbInletSize.items.add( fieldByName( 'InletSize' ).asstring );
      next;
    end;
    active := False;
  except
      MessageDlg( 'Could NOT load inlet list? '+sQuery+#13#10+#13#10+exception(exceptobject).message,
                  mtError, [mbOK], 0 );
  end;
  try
    if dmMain.wqryT.active then  begin
      dmMain.wqryT.active := False;
      messageDlg( 'Active error???', mterror, [mbok], 0 );
    end;
  except end;

  rzcbInletSize.ItemIndex := iOptionIndexWasB4DropDown; // put it back
end;

procedure TfSpringLookup.rzcbTempClassDropDown(Sender: TObject);
var
  i: integer;
  sQuery: string;
begin
  if lIgnoreOnChange then
    // building the list in OnCreate
    exit;

  iOptionIndexWasB4DropDown := rzcbTempClass.ItemIndex;

  if rzcbConsolSeries.ItemIndex <=-1 then begin
    messageDlg( 'You MUST pick a "Model Series" first', mtError, [mbok], 0 );
    exit;
  end;

  with dmMain.wqryT do try
    if active then begin
      MessageDLg( 'Something is wrong...wqryT is active?? contact support', mtInformation, [mbOK], 0 );
    end;
    active := false;
    sql.clear;
    sql.add( 'select distinct E.TempClassLetters from RvSpringChart E' );
    bAnd := False;
    AddConsolModelSeries( sql );

    // pressure matches??
    AddConsolPressure( sql );
    AddConsolOrifice( sql );
    AddConsolInlet( sql );
    AddConsolService( sql );

    //added build query into string incase we need it for error
    sQuery := '';
    try
      for i := 0 to SQL.Count-1 do
        sQuery := sQuery + SQL[i]+#13#10;
    except end;

    active := True;
    first;
    rzcbTempClass.Items.Clear;
    rzcbTempClass.items.add( '[All]' );
    while NOT EOF do begin
      rzcbTempClass.items.add( fieldByName( 'TempClassLetters' ).asstring );
      next;
    end;
    active := False;
  except
      MessageDlg( 'Could NOT load temp list? '+sQuery+#13#10+#13#10+exception(exceptobject).message,
                  mtError, [mbOK], 0 );
  end;
  try
    if dmMain.wqryT.active then  begin
      dmMain.wqryT.active := False;
      messageDlg( 'Active error???', mterror, [mbok], 0 );
    end;
  except end;

  rzcbTempClass.ItemIndex := iOptionIndexWasB4DropDown; // put it back
end;

procedure TfSpringLookup.sbSHowClick(Sender: TObject);
begin
  with dmMain.wqryRVSpringChart do begin
    if active = False then
      exit;
    fieldByName( 'Keyo1' ).Visible := True;
    fieldByName( 'UniqueKey' ).Visible := True;
    fieldByName( 'AddDate' ).Visible := True;
    fieldByName( 'WhoAdded' ).Visible := True;
  end;
end;

procedure TfSpringLookup.rzcbServiceDropDown(Sender: TObject);
var
  i: integer;
  sQuery: string;
begin
  if lIgnoreOnChange then
    // building the list in OnCreate
    exit;

  iOptionIndexWasB4DropDown := rzcbService.ItemIndex;

  if rzcbConsolSeries.ItemIndex <=-1 then begin
    messageDlg( 'You MUST pick a "Model Series" first', mtError, [mbok], 0 );
    exit;
  end;

  with dmMain.wqryT do try
    if active then begin
      MessageDLg( 'Something is wrong...wqryT is active?? contact support', mtInformation, [mbOK], 0 );
    end;
    active := false;
    sql.clear;
    sql.add( 'select distinct E.Service from RvSpringChart E' );
    bAnd := False;
    AddConsolModelSeries( sql );

    // pressure matches??
    AddConsolPressure( sql );
    AddConsolOrifice( sql );
    AddConsolInlet( sql );
    AddConsolTempClass( sql );

    //added build query into string incase we need it for error
    sQuery := '';
    try
      for i := 0 to SQL.Count-1 do
        sQuery := sQuery + SQL[i]+#13#10;
    except end;

    active := True;
    first;
    rzcbService.Items.Clear;
    rzcbService.items.add( '[All]' );
    while NOT EOF do begin
      rzcbService.items.add( fieldByName( 'Service' ).asstring );
      next;
    end;
    active := False;
  except
      MessageDlg( 'Could NOT load temp list? '+sQuery+#13#10+#13#10+exception(exceptobject).message,
                  mtError, [mbOK], 0 );
  end;
  try
    if dmMain.wqryT.active then  begin
      dmMain.wqryT.active := False;
      messageDlg( 'Active error???', mterror, [mbok], 0 );
    end;
  except end;

  rzcbService.ItemIndex := iOptionIndexWasB4DropDown; // put it back
end;

procedure TfSpringLookup.sbClearConsolSearchClick(Sender: TObject);
begin
  lIgnoreOnChange := True; // stop the firing of all onDropDowns

  try
  rzcbOrifice.items.Clear;
  rzcbInletSize.items.Clear;
  rzcbService.items.Clear;
  rzcbTempClass.items.Clear;
  except
      MessageDlg( 'Could NOT clear lists? '+#13#10+#13#10+exception(exceptobject).message,
                  mtError, [mbOK], 0 );
  end;

  lIgnoreOnChange := False;
  OpenConsolLookup;
end;

procedure TfSpringLookup.bbConSolReverseClick(Sender: TObject);
begin
  OpenConsolLookup;
end;

procedure TfSpringLookup.bbSetConsolSearchClick(Sender: TObject);
var
  sModel: string;
  iModel: integer;

  function DR1990: boolean;
  // you see, somtimes they get labeled 1996 and sometimes, the inlet
  //  size is in front as 1-1996. need to know both statuses
  var
    s: string;
    i: integer;
  begin
    result := FALSE;

    // the 1990 and 3990 series valves are a bit more complex.
    // somtimes they may be entered with a size dash on them, somtimes
    // this matters sometimes not. right now, simply check for the
    // 1990 & 3990 series and correctly mark dresser screwed

    for i := 1990 to 1998 do begin
      s := inttostr( i );
      if pos( s, sModel ) <> 0 then begin
        result := True;
        break;
      end;
    end;
    if result then
      // found, may as well leave...
      exit;
  end;

  function DR3900: boolean;
  // you see, somtimes they get labeled 1996 and sometimes, the inlet
  //  size is in front as 1-1996. need to know both statuses
  var
    s: string;
    i: integer;
  begin
    result := FALSE;
    for i := 3990 to 3999 do begin
      s := inttostr( i );
      if pos( s, sModel ) <> 0 then begin
        result := True;
        break;
      end;
    end;
  end;

begin
  if uppercase( dbtMan.Caption ) <> 'CONSOLIDATED' then begin
    MessageDlg( '"Current RV" manufacturer is NOT "Consolidated"', mtinformation, [mbOK], 0 );
    exit;
  end;

  // *******  I have exactly same code in Spring charts and Parts lookup   ********
  //
  // ***********   if this ever changes, change them too!!!     *********
  //
  //  *****  that's fEquip.FigureOutConSolSeries


  sModel := trim( dbtModel.caption );
  try
    iModel := strtoint( copy( sModel, 1, 4 ) );
  except
    iModel := 0
  end;

  rzcbConsolSeries.itemIndex := 0; // start with none!!
  if pos( '1982', sModel ) <> 0 then begin
    if rzcbConsolSeries.itemIndex <=0 then
      rzcbConsolSeries.itemIndex := rzcbConsolSeries.IndexOf( '1982');
  end;

  if DR1990 then begin
    if rzcbConsolSeries.itemIndex <=0 then
      rzcbConsolSeries.itemIndex := rzcbConsolSeries.IndexOf( '3900');
  end;

  if DR3900 then begin
    if rzcbConsolSeries.itemIndex <=0 then
      rzcbConsolSeries.itemIndex := rzcbConsolSeries.IndexOf( '3900');
  end;

  if ( iModel >= 1700 ) and ( iModel <= 1799 ) then begin
    if rzcbConsolSeries.itemIndex <=0 then
      rzcbConsolSeries.itemIndex := rzcbConsolSeries.IndexOf( '1700');
  end;

  if ( iModel >= 2700 ) and ( iModel <= 2799 ) then begin
    if rzcbConsolSeries.itemIndex <=0 then
      rzcbConsolSeries.itemIndex := rzcbConsolSeries.IndexOf( '2700');
  end;

  if ( iModel = 1510 ) or ( iModel = 1511 ) or (pos('1510', sModel)<>0) or (pos('1511', sModel)<>0) then begin
    if rzcbConsolSeries.itemIndex <=0 then
      rzcbConsolSeries.itemIndex := rzcbConsolSeries.IndexOf( '1511');
  end;
  if ( iModel = 1541 ) or (pos('1541', sModel)<>0) then begin
    if rzcbConsolSeries.itemIndex <=0 then
      rzcbConsolSeries.itemIndex := rzcbConsolSeries.IndexOf( '1541');
  end;
  if ( iModel = 1543 ) or (pos('1543', sModel)<>0) then begin
    if rzcbConsolSeries.itemIndex <=0 then
      rzcbConsolSeries.itemIndex := rzcbConsolSeries.IndexOf( '1543');
  end;

  if ( iModel = 1811 ) or (pos('1811', sModel)<>0) then begin
    if rzcbConsolSeries.itemIndex <=0 then
      rzcbConsolSeries.itemIndex := rzcbConsolSeries.IndexOf( '1811');
  end;

  try
    iModel := strtoint( copy( sModel, 1, 5 ) );
  except
    iModel := 0
  end;
  if iModel >= 19000 then begin
    if rzcbConsolSeries.itemIndex <=0 then
      rzcbConsolSeries.itemIndex := rzcbConsolSeries.IndexOf( '19000');
  end;

  // this needs to be AFTER the 19000 search!!!
  sModel := trim( dbtModel.caption );
  try
    //BACK to 4 digits
    iModel := strtoint( copy( sModel, 1, 4 ) );
  except
    iModel := 0
  end;

  if (iModel >= 1900) and (iModel <=1999) then begin
    if pos( '/P', sModel ) <> 0 then begin
      if rzcbConsolSeries.itemIndex <=0 then
        rzcbConsolSeries.itemIndex := rzcbConsolSeries.IndexOf( '1900/P');
      end
    else begin
      if rzcbConsolSeries.itemIndex <=0 then
        rzcbConsolSeries.itemIndex := rzcbConsolSeries.IndexOf( '1900');
    end;
  end;

  if rzcbConsolSeries.itemIndex <=0 then begin
    MessageDLg( 'Could not figure out Model Series from: '+sModel+'  | '+inttostr( iModel)+#13#10+#13#10+
                'Please consult Tech Support to help us add this.', mtError, [mbok], 0 );
    exit;
  end;
  rzcbConsolSeries.OnChange( rzcbConsolSeries );
  rzcbOrifice.OnDropDown( rzcbOrifice );

  //see if there IS an oring material...if yesm

  sModel := trim( dbtOrifice.Caption );
  if rzcbOrifice.IndexOf( sModel ) <> 0 then begin
    rzcbOrifice.itemIndex := rzcbOrifice.IndexOf( sModel );
    end
  else
    rzcbOrifice.itemIndex := 0;
  //19000 special handle
  if (rzcbConsolSeries.Text = '19000') and (rzcbOrifice.Items.Count >= 6) then begin
    if pos( '19096', dbtModel.Caption ) <> 0 then
      rzcbOrifice.itemIndex := 1;
    if pos( '19110', dbtModel.Caption ) <> 0 then
      rzcbOrifice.itemIndex := 2;
    if pos( '19126', dbtModel.Caption ) <> 0 then
      rzcbOrifice.itemIndex := 3;
    if pos( '19226', dbtModel.Caption ) <> 0 then
      rzcbOrifice.itemIndex := 4;
    if pos( '19357', dbtModel.Caption ) <> 0 then
      rzcbOrifice.itemIndex := 5;
    if pos( '19567', dbtModel.Caption ) <> 0 then
      rzcbOrifice.itemIndex := 6;
  end;
//  rzcbOrifice.OnChange( rzcbOrifice );
  rzcbInletSize.OnDropDown( rzcbInletSize );

  sModel := uppercase( trim( dbtInlet.Caption ) );
  if (copy( sModel, 1, 3 ) = '1/2') or (copy( sModel, 1, 3 ) = '0.5') or (copy( sModel, 1, 2 ) = '.5') then begin
    rzcbInletSize.itemIndex := rzcbInletSize.IndexOf( '0.5' );
  end;
  if (copy( sModel, 1, 3 ) = '3/4') or (copy( sModel, 1, 4 ) = '0.75') or (copy( sModel, 1, 3 ) = '.75') then begin
    rzcbInletSize.itemIndex := rzcbInletSize.IndexOf( '0.75' );
  end;
  if copy( sModel, 1, 1 ) = '2' then begin
    rzcbInletSize.itemIndex := rzcbInletSize.IndexOf( '2' );
    if (pos('.5', sModel)<>0) or (pos('1', sModel)<>0) then
      rzcbInletSize.itemIndex := rzcbInletSize.IndexOf( '2.5' );
  end;
  if copy( sModel, 1, 1 ) = '3' then begin
    rzcbInletSize.itemIndex := rzcbInletSize.IndexOf( '3' );
  end;
  if copy( sModel, 1, 1 ) = '4' then begin
    rzcbInletSize.itemIndex := rzcbInletSize.IndexOf( '4' );
  end;
  if copy( sModel, 1, 1 ) = '6' then begin
    rzcbInletSize.itemIndex := rzcbInletSize.IndexOf( '6' );
  end;
  if copy( sModel, 1, 1 ) = '8' then begin
    rzcbInletSize.itemIndex := rzcbInletSize.IndexOf( '8' );
  end;
  if copy( sModel, 1, 2 ) = '10' then begin
    rzcbInletSize.itemIndex := rzcbInletSize.IndexOf( '10' );
  end;
  if copy( sModel, 1, 2 ) = '12' then begin
    rzcbInletSize.itemIndex := rzcbInletSize.IndexOf( '12' );
  end;

  // handle all the possible 1's...
  if (rzcbInletSize.itemIndex <= 0) and (copy( sModel, 1, 1 ) = '1') then begin
    if (pos('.5', sModel)<>0) or (pos('2', sModel)<>0) then
      rzcbInletSize.itemIndex := rzcbInletSize.IndexOf( '1.5' );
    if (pos('.2', sModel)<>0) or (pos('1/4', sModel)<>0) then
      rzcbInletSize.itemIndex := rzcbInletSize.IndexOf( '1.25' );
    if (pos('.7', sModel)<>0) or (pos('3/4', sModel)<>0) then
      rzcbInletSize.itemIndex := rzcbInletSize.IndexOf( '1.75' );
    if rzcbInletSize.itemIndex <= 0 then
      rzcbInletSize.itemIndex := rzcbInletSize.IndexOf( '1' );
  end;
  //inletOnChange()
  rzcbService.OnDropDown( rzcbService );

  sModel := uppercase( trim( dbtService.Caption ) );
  if sModel = '' then
    // the service field is later on in the details forms....
    // i COULD ask them OR just try product.  asking might be too much, so,
    //   for now, just try with product
    sModel := uppercase( trim( dbtProduct.Caption ) );

  if pos( 'STEA', sModel )<>0 then begin
    rzcbService.itemIndex := rzcbService.IndexOf( 'Steam' );
  end;
  if (pos( 'GAS', sModel )<>0) or (pos( 'COM', sModel )<>0) or (pos( 'AIR', sModel )<>0) or (pos( 'VAP', sModel )<>0) then begin
    rzcbService.itemIndex := rzcbService.IndexOf( 'Gas/Vapor' );
    if rzcbService.itemIndex <=0 then
      rzcbService.itemIndex := rzcbService.IndexOf( 'Gas/Vapour' );
    if rzcbService.itemIndex <=0 then
      rzcbService.itemIndex := rzcbService.IndexOf( 'Gas' );
    if rzcbService.itemIndex <=0 then
      rzcbService.itemIndex := rzcbService.IndexOf( 'Vapour' );
    if rzcbService.itemIndex <=0 then
      rzcbService.itemIndex := rzcbService.IndexOf( 'Vapor' );
  end;
  if (pos( 'LIQ', sModel )<>0) or (pos( 'NON', sModel )<>0) or (pos( 'WATER', sModel )<>0) then begin
    rzcbService.itemIndex := rzcbService.IndexOf( 'Liquid' );
  end;
  rzcbTempClass.OnDropDown( rzcbTempClass );

  if dbtTemp.Field.Value > 450.0 then
    rzcbTempClass.itemIndex := rzcbTempClass.IndexOf( 'T' )
  else
    rzcbTempClass.itemIndex := rzcbTempClass.IndexOf( 'C' );


  // give them the list
  OpenConsolLookup;
end;

procedure TfSpringLookup.wwDBGrid1RowChanged(Sender: TObject);
begin
  try
  edConSolReverse.text := dmMain.Query2.fieldByName( 'SPRINGMARKING' ).AsString;
  except
  edConSolReverse.text := '';
  end;
end;

procedure TfSpringLookup.cbSortCountClick(Sender: TObject);
var
  b: boolean;
begin
  // reget the query
  fSpringLookup.rzpcSearchChanging( fSpringLookup.rzpcSearch, 3, b );
end;

procedure TfSpringLookup.wwDBGrid2RowChanged(Sender: TObject);
begin
  try
  edSpringRevExisting.text := dmMain.Query2.fieldByName( 'SPRINGnumber' ).AsString;
  except
  edSpringRevExisting.text := '';
  end;
end;

procedure TfSpringLookup.cbOwnerOnlyClick(Sender: TObject);
var
  b:boolean;
begin
  if lIgnoreOnChange then
    // at some point, i (in code) set the .checked and it causes thia
    //  event to fire again... which redoes the "search" which causes grief
    //  SO, i mess with lIgnoreOnChange to prevent this
    //  it occurs because i allow real-time checking of the "owner" and "plant"
    //   filters; and they immediately change the SQL (ie. fire bbSearch.click)
    exit;

  // IF they're on the reverse lookup, reget the "frequency" query
  if rzpcSearch.TabIndex = 3 then begin
    fSpringLookup.rzpcSearchChanging( fSpringLookup.rzpcSearch, 3, b );
  end;
  // reget whatever they were looking it
  bbSearch.click;
end;

procedure TfSpringLookup.bbTransferClick(Sender: TObject);
begin
  If messageDLg( 'Transfer spring data to the valve?'+#13#10+#13#10+
                 'This spring data is provided as reference ONLY!'+#13#10+#13#10+
                 'You are fully responsible for the accuracy and fitness of the data!'+#13#10+#13#10+
                 'You MUST still verify spring data with manufacturer as this data'+#13#10+
                 'may be out of date!!!' , mtconfirmation, [mbyes,mbno], 0 ) <> mrYes then
    exit;

  with fEquip.qe do begin
    if active = false then
      // in theory the button's .visible is false for not in edit/add mode but check anyway
      exit;
    try
      if dmMain.wqryT.active then begin
        // from existing data
        fieldByName( 'SpringNumber' ).asstring := dmMain.wqryT.fieldByName( 'SpringNumber' ).asstring;
        fieldByName( 'SpringMat' ).asstring := dmMain.wqryT.fieldByName( 'SpringMat' ).asstring;
        fieldByName( 'SpringRangFrom' ).asstring := dmMain.wqryT.fieldByName( 'SpringRangFrom' ).asstring;
        fieldByName( 'SpringRangeTo' ).asstring := dmMain.wqryT.fieldByName( 'SpringRangeTo' ).asstring;
      end;
      if dmMain.wqryRVSpringChart.active then begin
        // from consolidated data
        fieldByName( 'SpringNumber' ).asstring := dmMain.wqryRVSpringChart.fieldByName( 'SpringMarking' ).asstring;
        fieldByName( 'SpringMat' ).asstring := dmMain.wqryRVSpringChart.fieldByName( 'Extra3' ).asstring;
        fieldByName( 'SpringRangFrom' ).asstring := formatFloat( '0.', dmMain.wqryRVSpringChart.fieldByName( 'EI1' ).value );
        fieldByName( 'SpringRangeTo' ).asstring := formatFloat( '0.', dmMain.wqryRVSpringChart.fieldByName( 'EI2' ).value )
      end;
    except
      MessageDlg( 'Could NOT plug in spring data? '+#13#10+#13#10+exception(exceptobject).message,
                  mtError, [mbOK], 0 );
    end;
  end;
end;

end.