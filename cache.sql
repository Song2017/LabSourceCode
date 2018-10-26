  CREATE TABLE "WPUSERNAMEMAPPING" 
   (	
    "UNIQUEKEY" VARCHAR2(40 BYTE), 
	"TENANTKEY" VARCHAR2(50 BYTE), 
	"WPFIELDKEY" VARCHAR2(100 BYTE), 
	"VKFIELDNAME" VARCHAR2(100 BYTE), 
	"EQUIPTYPE" NUMBER, 
	"CREATEDBY" VARCHAR2(40 BYTE), 
	"CREATEDATE" TIMESTAMP(6) DEFAULT CURRENT_TIMESTAMP, 
	"POSTEDBY" VARCHAR2(40 BYTE), 
	"POSTDATE" TIMESTAMP(6) DEFAULT CURRENT_TIMESTAMP
   )  ;

COMMENT ON COLUMN "WPUSERNAMEMAPPING"."EQUIPTYPE" IS 'RV 0/CV 1/PART 5/MOV/LV';
CREATE UNIQUE INDEX "WPUSERNAMEMAPPING_PK" ON "WPUSERNAMEMAPPING" ("UNIQUEKEY"); 
CREATE INDEX "WPUSERNAMEMAPPING_EQUIPTYPE" ON "WPUSERNAMEMAPPING" ("EQUIPTYPE"); 
ALTER TABLE "WPUSERNAMEMAPPING" ADD CONSTRAINT "WPUSERNAMEMAPPING_PK" PRIMARY KEY ("UNIQUEKEY");
ALTER TABLE "WPUSERNAMEMAPPING" MODIFY ("EQUIPTYPE" NOT NULL ENABLE);
ALTER TABLE "WPUSERNAMEMAPPING" MODIFY ("VKFIELDNAME" NOT NULL ENABLE);
ALTER TABLE "WPUSERNAMEMAPPING" MODIFY ("WPFIELDKEY" NOT NULL ENABLE);
ALTER TABLE "WPUSERNAMEMAPPING" MODIFY ("TENANTKEY" NOT NULL ENABLE);
ALTER TABLE "WPUSERNAMEMAPPING" MODIFY ("UNIQUEKEY" NOT NULL ENABLE);







  create or replace PROCEDURE USPWPGETVKMAPPINGUSERNAME (
    IN_USERKEY IN VARCHAR2,
    IN_EQUIPTYPE IN NUMBER,
    OUT_CURSOR OUT SYS_REFCURSOR)
AS
  V_TEMPLATEID VARCHAR2 (40) ;
  V_TENANTKEY VARCHAR2 (40) ;
  V_TABLE VARCHAR2 (40) ;
  V_FLEVEL NUMBER (5) ;
BEGIN
  V_TENANTKEY:=UFGETTENANTKEYBYUSER (IN_USERKEY) ;
  V_TEMPLATEID:=UFGETTEMPLATEIDBYUSER (IN_USERKEY) ;
   SELECT FLPLEVEL
     INTO V_FLEVEL
     FROM VKUSER
    WHERE USERID=IN_USERKEY
    AND TENANTKEY=V_TENANTKEY;

   SELECT
    CASE IN_EQUIPTYPE WHEN 0 THEN 'RELIEFD' WHEN 1 THEN 'CV' WHEN 5 THEN 'PART' ELSE 'RELIEFD' END
     INTO V_TABLE
     FROM DUAL; 

  -- vkc template field
  OPEN OUT_CURSOR FOR
  WITH A AS
    (SELECT DATA_TYPE, COLUMN_NAME
       FROM ALL_TAB_COLUMNS
      WHERE TABLE_NAME=V_TABLE
    )
   SELECT FDE.USERNAME, FDE.DATAFIELD FIELDNAME,
    (SELECT DATA_TYPE FROM A WHERE COLUMN_NAME=FDE.DATAFIELD
    ) DATATYPE
     FROM FIELDDEFINITION FDE
  LEFT JOIN FLP
       ON (FLP.FLPLEVEL=V_FLEVEL
    AND FLP.FIELDNUMBER=FDE.FIELDNUMBER
    AND FLP.TENANTKEY=V_TENANTKEY)
    WHERE TEMPLATEID=V_TEMPLATEID
    AND EQUIPTYPE=IN_EQUIPTYPE
    AND ( (FLP.CANVIEW=1
    OR FLP.CANVIEW IS NULL)
    AND (FDE.VISIBLE='T'
    OR FDE.VISIBLE IS NULL))
  ORDER BY FDE.USERNAME ;


END;

CREATE OR REPLACE PROCEDURE USPWPGETVKERNAME (
    IN_USERKEY IN VARCHAR2,
    IN_EQUIPTYPE IN NUMBER,
    OUT_CURSOR OUT SYS_REFCURSOR)
AS
  V_TEMPLATEID VARCHAR2 (40) ;
  V_TENANTKEY VARCHAR2 (40) ;
BEGIN
  V_TENANTKEY:=UFGETTENANTKEYBYUSER (IN_USERKEY) ;
  V_TEMPLATEID:=UFGETTEMPLATEIDBYUSER (IN_USERKEY) ;

  -- vkc template field
  OPEN OUT_CURSOR FOR SELECT WV.UNIQUEKEY, WV.WPFIELDKEY, WV.EQUIPTYPE,
  (SELECT USERNAME
     FROM WPSTAGINGFIELDDEFINITION
    WHERE UNIQUEKEY=WV.WPFIELDKEY
  ) WPUSERNAME,
  (SELECT USERNAME
     FROM FIELDDEFINITION FDE
    WHERE FDE.DATAFIELD=VKFIELDNAME
    AND FDE.EQUIPTYPE=IN_EQUIPTYPE
    AND FDE.TEMPLATEID=V_TEMPLATEID
    AND FDE.TENANTKEY=V_TENANTKEY
  ) VKUSERNAME FROM WPUSERNAMEMAPPING WV 
  WHERE TENANTKEY=V_TENANTKEY AND EQUIPTYPE=IN_EQUIPTYPE 
  ORDER BY WPUSERNAME, VKUSERNAME ;


END;