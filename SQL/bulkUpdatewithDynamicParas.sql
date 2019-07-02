/*
oracle bulk update with dynamic paras:
1. table name
2. target column & based column
3. condition
4. update records

solution:
1. UFSPLITSTRING_NCLOB: split dynamic string 
	ISDATE: Check if it is a date column
2. user defined table type: tranfer string to table 
	https://docs.oracle.com/cd/A57673_01/DOC/server/doc/PLS23/ch4.htm
3. while loop..endloop: bulk records update
4. EXECUTE IMMEDIATE sql: update dynamic sql
	https://docs.oracle.com/cd/B19306_01/appdev.102/b14261/dynamic.htm
*/

-- create base type
CREATE OR REPLACE TYPE SPLITSTRINGROW_UNI_TYPE
AS
  OBJECT
  (
    ID NUMBER(5),
    TOKEN NVARCHAR2(200) );
  /
  --create table type
CREATE OR REPLACE TYPE "SPLITSTRINGTABLE_UNI"
AS
  TABLE OF SPLITSTRINGROW_UNI_TYPE;
  /
  --create string split function
CREATE OR REPLACE FUNCTION UFSPLITSTRING_NCLOB(
  INSTRING IN NCLOB,
  DELIM IN CHAR,
  KEEPCRLF CHAR := 'F')
RETURN SPLITSTRINGTABLE_UNI
AS
  /******************************************************************************
  select * FROM  TABLE(UFSPLITSTRING('other3|t - rh7|fghj - hg7|df - sg3|s - s14|bvg - kj7|', '|')) p;
  *******************************************************************************/
  CR CHAR(1);
  LF CHAR(1);
  POS NUMBER(5);
  ID NUMBER(5);
  I1 NUMBER(5);
  I2 NUMBER(5);
  TOKEN NVARCHAR2(2000);
  V_INSTRING NCLOB;
  V_TABLE SPLITSTRINGTABLE_UNI := SPLITSTRINGTABLE_UNI();
BEGIN
  CR := CHR(10);
  LF := CHR(13);
  ID := 0;
  V_INSTRING := INSTRING;
  IF ( V_INSTRING IS NOT NULL AND LENGTH(V_INSTRING) > 0 ) THEN
    V_INSTRING := V_INSTRING || DELIM;
    POS := INSTR(V_INSTRING, DELIM);
    WHILE ( POS <> 0 )
    LOOP
      TOKEN := TRIM(SUBSTR(V_INSTRING, 1, POS - 1));
      IF KEEPCRLF = 'F' THEN
        TOKEN := REPLACE(TOKEN, CR, '');
        TOKEN := REPLACE(TOKEN, LF, '');
      END IF;
      IF POS - LENGTH(V_INSTRING) = 0 THEN
        POS := 0;
      ELSE
        V_INSTRING := SUBSTR(V_INSTRING, POS - LENGTH(V_INSTRING));
        POS := INSTR(V_INSTRING, DELIM);
      END IF;
      IF( TOKEN IS NOT NULL ) THEN
        ID := ID + 1;
        V_TABLE.EXTEND;
        V_TABLE(V_TABLE.LAST) := NEW SPLITSTRINGROW_UNI_TYPE(ID, TOKEN);
      END IF;
    END LOOP;
  END IF;
  RETURN V_TABLE;
END ;
/
--check for column is validate
CREATE OR REPLACE FUNCTION ISDATE(
    STR IN VARCHAR2)
  RETURN NUMBER
AS
  V_RESULT DATE;
BEGIN
  IF (STR IS NULL) THEN
    RETURN 0;
  END IF;
  IF(LENGTH(STR) = 14 OR LENGTH(STR) = 19) THEN
    V_RESULT := TO_DATE(STR,'yyyy-mm-dd hh24:mi:ss');
  ELSE
    V_RESULT := TO_DATE(STR,'YYYY/MM/DD');
  END IF;
  RETURN 1;
EXCEPTION
WHEN OTHERS THEN
  RETURN 0;
END ISDATE;
/
CREATE OR REPLACE PROCEDURE BULKUPDATEWITHDYNAMICPARAS(
    IN_TABLENAME IN NUMBER, -- 0, 1, 4, 5
    IN_WHERECONDITION IN NUMBER, -- 0, 1
    IN_UNIQUEKEYS IN NCLOB,--'1,2,3'
    IN_BASECOLUMN IN VARCHAR2, --BASECOLUMN/12
    IN_TARGETCOLUMNS IN VARCHAR2, --'TargetCol1|TargetCol1REQ,TargetCol2|TargetCol2REQ'
    OUT_EDITEDROWCOUNT OUT NUMBER) -- return to application how many records updated
AS
  /******************************************************************************
  **  FILE:        bulkUpdatewithDynamicParas.SQL
  **  DESCRIPTION: BULK UPDATE DATES
  **  RETURNS:     return to application how many records updated
  *******************************************************************************
  **  CHANGE HISTORY
  *******************************************************************************/
  V_UNIQUEKEYS VARCHAR2 (30000):= ' ';
  V_BEGINNUM NUMBER:=0;
  V_ENDNUM NUMBER:=0;
  V_SQL VARCHAR2 (30000) ;
  V_UPDATESQL VARCHAR2 (30000) ;
  V_BASECOLUMNSQL NVARCHAR2 (500) ;
BEGIN
  OUT_EDITEDROWCOUNT:= 0;
  V_SQL :=' UPDATE ';
  -- update table by equip type
  IF IN_TABLENAME =0 THEN
    V_SQL :=V_SQL || ' tab0 SET ';
  ELSIF IN_TABLENAME=1 THEN
    V_SQL :=V_SQL || ' tab1 SET ';
  ELSIF IN_TABLENAME=4 THEN
    V_SQL :=V_SQL || ' tab4 SET ';
  ELSIF IN_TABLENAME=5 THEN
    V_SQL :=V_SQL || ' tab5 SET ';
  END IF ;
  -- update column: concat columns to be updated
  IF IN_BASECOLUMN='BASECOLUMN' THEN
    SELECT   LISTAGG (TO_CHAR (UPDATENAME), ',') WITHIN GROUP (
      ORDER BY 1)
      INTO V_BASECOLUMNSQL
      FROM
        (SELECT   REGEXP_SUBSTR (TO_CHAR (TOKEN), '[^|]+', 1, 1) || '=DECODE (ISDATE (' ||IN_BASECOLUMN ||
            '), 0, NULL ,TO_CHAR (ADD_MONTHS (TO_DATE (' ||IN_BASECOLUMN ||', ''YYYY/MM/DD''), ' || REGEXP_SUBSTR (TO_CHAR ( TOKEN), '[^|]+$') ||
            '),''YYYY/MM/DD''))' AS UPDATENAME
          FROM TABLE (UFSPLITSTRING_NCLOB (IN_TARGETCOLUMNS, ','))
        ) ;
  ELSE
    SELECT   LISTAGG (TO_CHAR (UPDATENAME), ',') WITHIN GROUP (
      ORDER BY 1)
      INTO V_BASECOLUMNSQL
      FROM
        (SELECT   REGEXP_SUBSTR (TO_CHAR (TOKEN), '[^|]+', 1, 1) || '=DECODE (ISDATE (' ||REGEXP_SUBSTR (TO_CHAR (TOKEN), '[^|]+', 1, 1) ||
            '), 0, NULL ,TO_CHAR (ADD_MONTHS (TO_DATE (' || REGEXP_SUBSTR (TO_CHAR (TOKEN), '[^|]+', 1, 1) || ', ''YYYY/MM/DD''), ' ||TO_NUMBER (
            IN_BASECOLUMN) ||'),''YYYY/MM/DD''))' AS UPDATENAME
          FROM TABLE (UFSPLITSTRING_NCLOB (IN_TARGETCOLUMNS, ','))
        ) ;
  END IF;
  V_SQL := V_SQL || V_BASECOLUMNSQL;
  -- update condition: add by user self
  V_SQL := V_SQL || ' WHERE 1=1 ';
  -- for your custumed business logic where condition
  IF IN_WHERECONDITION = 1 THEN
    V_SQL := V_SQL || ' AND (1 = 1 OR 2 = 2) ' ;
  END IF;
  -- update bulk: 100 records
  V_SQL := V_SQL || ' AND UNIQUEKEY IN ';
  WHILE V_UNIQUEKEYS IS NOT NULL
  LOOP
    V_BEGINNUM:= 1 + V_ENDNUM;
    V_ENDNUM:=V_BEGINNUM+99;
    SELECT   LISTAGG (''''||TO_CHAR (TOKEN) ||'''', ',') WITHIN GROUP (
      ORDER BY ID)
      INTO V_UNIQUEKEYS
      FROM TABLE (UFSPLITSTRING_NCLOB (IN_UNIQUEKEYS, ','))
      WHERE ID BETWEEN V_BEGINNUM AND V_ENDNUM;
    IF V_UNIQUEKEYS IS NULL THEN
      EXIT;
    END IF;
    V_UPDATESQL := V_SQL || ' (' || V_UNIQUEKEYS || ') ';
    --dbms_output.put_line(V_UPDATESQL);
    EXECUTE IMMEDIATE V_UPDATESQL;
    OUT_EDITEDROWCOUNT := OUT_EDITEDROWCOUNT + TO_NUMBER(SQL%ROWCOUNT);
  END LOOP;
END IF;
END;