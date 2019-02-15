
DECLARE
  V_UNIQUEKEY VARCHAR2 (40) ;
  V_COUNT NUMBER (10) ;
TYPE T_LV IS VARRAY (20) OF VARCHAR2 (30) ;
V_LVNAME T_LV:=T_LV ('MODEL_NUMBER', 'MANUFACTURER', 'MFG_SERIES', 'ARCHIVED', 'NOTES', 'RELIEF_STYLE',
'RV_TRAVELLER_TYPE', 'RV_ORIFICE_DESG', 'RV_ORIFICE_AREA', 'RV_CAP', 'RV_BONNET', 'RV_INLET_SIZE', 'RV_OUTLET_SIZE',
'RV_INLET_FACING', 'RV_OUTLET_FACING', 'RV_INLET_RATING', 'RV_OUTLET_RATING', 'ExN1', 'RECPOSTEDBY', 'RECCREATEDBY') ;
V_LVFIELD T_LV:=T_LV ('Model Number', 'Manufacture', 'MFG Series', 'Archived', 'Notes', 'Relief Style',
'Traveller Type', 'Orifice Desg', 'Orifice Area', 'Cap', 'Bonnet', 'Inlet Size', 'Outlet Size', 'Inlet Facing',
'Outlet Facing', 'Inlet Rating', 'Outlet Rating', 'Mfg Lift', 'Posted By', 'Created By') ;
V_LVNUMBER T_LV:=T_LV ('9999', '9999', '9999', '9999', '9999', '9999', '9999', '9999', '9999', '9999', '9999', '9999',
'9999', '9999', '9999', '9999', '9999', '9999', '9999', '9999') ;
BEGIN
  DECLARE
    CURSOR CUR
    IS
       SELECT UNIQUEKEY
         FROM TENANT
        WHERE TENANTKEY='61E39FA31A874996B8597CDCC06735E9';
    ROW_TEMP CUR%ROWTYPE;
  BEGIN
    OPEN CUR;
    FETCH CUR INTO ROW_TEMP;
    WHILE CUR%FOUND
    LOOP
      BEGIN
        V_UNIQUEKEY:=ROW_TEMP.UNIQUEKEY;
        --DBMS_OUTPUT.PUT_LINE (V_UNIQUEKEY) ;
        --LV
        FOR I IN 1..V_LVNAME.COUNT
        LOOP
          V_COUNT:=0;
           SELECT COUNT (*)
             INTO V_COUNT
             FROM VKC2.GRIDDEFAULTFIELD
            WHERE TENANTKEY=V_UNIQUEKEY
            AND GRIDDATASOURCE='uspGetAVModelReliefD'
            AND QUERYTYPE='SELECT'
            AND DATATABLE='AVMODEL'
            AND FIELDNAME=V_LVNAME (I) ;
          IF (V_COUNT=0) THEN
             INSERT
               INTO VKC2.GRIDDEFAULTFIELD
              (
                UNIQUEKEY, TENANTKEY, GRIDDATASOURCE, QUERYTYPE, DATATABLE, FIELDNAME, DISPLAYNAME, FIELDNUM, SEQNO,
                SHOW, VALUE, CREATEDATE, EDITDATE, FIELDTYPE
              )
              VALUES
              (
                SEQ_GRIDDEFAULTFIELDUK.NEXTVAL, V_UNIQUEKEY, 'uspGetAVModelReliefD', 'SELECT', 'AVMODEL', V_LVNAME (I),
                V_LVFIELD (I), TO_NUMBER (V_LVNUMBER (I)), 0, 'T', '150', TO_CHAR (SYSDATE, 'YYYY/MM/DD'), TO_CHAR (
                SYSDATE, 'YYYY/MM/DD'), NULL
              ) ;
          END IF;
        END LOOP;

        FETCH CUR INTO ROW_TEMP;
      END;
    END LOOP;
    CLOSE CUR;
  END;