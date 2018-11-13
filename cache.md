dtgSpring.Columns["MODELSERIES"].Caption = GetGlobalResourceObject("UiResource", "Detail_Config_SpringChart_Tab1_Col1").ToStringEx();
dtgSpring.Columns["OPTION3"].Caption = GetGlobalResourceObject("UiResource", "Detail_Config_SpringChart_Tab1_Col2").ToStringEx();
dtgSpring.Columns["PRESSURECLASS"].Caption = GetGlobalResourceObject("UiResource", "Detail_Config_SpringChart_Tab1_Col3").ToStringEx();
dtgSpring.Columns["SERVICE"].Caption = GetGlobalResourceObject("UiResource", "Detail_Config_SpringChart_Tab1_Col4").ToStringEx();
dtgSpring.Columns["INLETSIZE"].Caption = GetGlobalResourceObject("UiResource", "Detail_Config_SpringChart_Tab1_Col5").ToStringEx();
dtgSpring.Columns["TEMPCLASSLETTERS"].Caption = GetGlobalResourceObject("UiResource", "Detail_Config_SpringChart_Tab1_Col6").ToStringEx();
dtgSpring.Columns["ORIFICE"].Caption = GetGlobalResourceObject("UiResource", "Detail_Config_SpringChart_Tab1_Col7").ToStringEx();
dtgSpring.Columns["OPTION1"].Caption = GetGlobalResourceObject("UiResource", "Detail_Config_SpringChart_Tab1_Col8").ToStringEx();
dtgSpring.Columns["OPTION2"].Caption = GetGlobalResourceObject("UiResource", "Detail_Config_SpringChart_Tab1_Col9").ToStringEx();
dtgSpring.Columns["BOOL1"].Caption = GetGlobalResourceObject("UiResource", "Detail_Config_SpringChart_Tab1_Col10").ToStringEx();
dtgSpring.Columns["EXTRA"].Caption = GetGlobalResourceObject("UiResource", "Detail_Config_SpringChart_Tab1_Col11").ToStringEx();
dtgSpring.Columns["EXTRA1"].Caption = GetGlobalResourceObject("UiResource", "Detail_Config_SpringChart_Tab1_Col12").ToStringEx();
dtgSpring.Columns["EXTRA2"].Caption = GetGlobalResourceObject("UiResource", "Detail_Config_SpringChart_Tab1_Col13").ToStringEx();
dtgSpring.Columns["PRESSUREFROM"].Caption = GetGlobalResourceObject("UiResource", "Detail_Config_SpringChart_Tab1_Col14").ToStringEx();
dtgSpring.Columns["PRESSURETO"].Caption = GetGlobalResourceObject("UiResource", "Detail_Config_SpringChart_Tab1_Col15").ToStringEx();



Series -> MODELSERIES 
Spring Number -> SPRINGMARKING  as SPRINGNUMBER  
Spring Material -> EXTRA3  as SPRINGMAT
Press From -> EI1 as SPRINGRANGFROM
Press To -> EI2  as SPRINGRANGETO
Style -> OPTION3   
Press Class -> PRESSURECLASS
Temp Class -> TEMPCLASSLETTERS
Orifice -> ORIFICE
Inlet Size ->INLETSIZE
Service -> SERVICE
Construction -> OPTION1
O- Ring -> OPTION2
UM? -> BOOL1
Exposed Spring -> EXTRA
Pilot -> EXTRA1
Pilot Press Class -> EXTRA2
Press From (text) ->PRESSUREFROM
Press To (text) -> PRESSURETO


Verify IN catalog FIRST, BUT for 1900 series higher pressures, you can use 1900 conventional (ie. change to NO O-Ring) data
请先在目录中进行确认,对1900系列更高的压力，您可以用1900常规数据(例如，改变为非O型环)


CREATE INDEX IDX_RVSPRGUID ON RVSPRINGCHART (SP_GUID);
CREATE INDEX IDX_RVSPRMODELKEY ON RVSPRINGCHART (MODELKEY);
CREATE INDEX IDX_RVSPRMODELNUMBER ON RVSPRINGCHART (MODELNUMBER);
CREATE INDEX IDX_RVSPRMODELNUMBERSIMPLE ON RVSPRINGCHART (MODELNUMBERSIMPLE);
CREATE INDEX IDX_RVSPRMODELSERIES ON RVSPRINGCHART (MODELSERIES);
CREATE INDEX IDX_RVSPRORIFICE ON RVSPRINGCHART (ORIFICE);
CREATE INDEX IDX_RVSPRPRESSUREFROM ON RVSPRINGCHART (PRESSUREFROM);
CREATE INDEX IDX_RVSPRPRESSURETO ON RVSPRINGCHART (PRESSURETO);
CREATE INDEX IDX_RVSPRSPRINGMARKING ON RVSPRINGCHART (SPRINGMARKING);


dx:ASPxLabel

LabelSPRINGMODELNUMBER 
LabelMANUFACTURER LabelSPRINGNUMBER lblSpringLookupCDTPValue

LabelSPRINGRANGFROM  LabelSPINGSERVICE lblSpringSETPRESSValue
LabelSPRINGRANGETOC LabelSpringCODESTAMP LabelSpringASMECAPACITY
LabelSPRINGMATC LabelSpringSTYLE LabelOPERATINGTEMP
LabelSpringTAGNUMBER LabelSpringCAPTYPE LabelORIFDESIGNATION
LabelSpringSOFTSEATMAT LabeINLETSIZE