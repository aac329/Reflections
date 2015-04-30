use dls 
-- This script gives SuperUser access to the specified UserID.
-- The script must be run on the database corresponding to the
-- development site on which access is needed:
--
-- Contedsrv/dev = localhost
-- Contedsrv/dls = admindev.distance.nau.edu or dev.distance.nau.edu

-- Leave this line alone.
DECLARE @User_ID AS Int

SELECT @User_ID='1490'

-- ///////////////////////////////////////////////////////////////////
-- DO NOT EDIT BELOW THIS LINE!

UPDATE Admin_Users SET  Super_User='Y'
WHERE User_ID = @User_ID;

--Acad Orgs
DELETE FROM Admin_User_Orgs WHERE User_ID=@User_ID;

INSERT INTO Admin_User_Orgs (User_ID, Acad_Org_Code, Use_In_Processing, Use_In_Reporting)
(select Distinct @User_ID, aaa.Acad_Org_Code,'Y','Y' from Admin_User_Orgs aaa);



--Campuses
DELETE FROM Admin_User_Campuses WHERE User_ID=@User_ID;

INSERT INTO Admin_User_Campuses (User_ID, Campus_Code, Use_In_Processing, Use_In_Reporting)
(select Distinct @User_ID, aaa.Campus_Code,'Y','Y' from Admin_User_Campuses aaa);


--Menus
DELETE FROM Admin_User_Options WHERE User_ID=@User_ID;

INSERT INTO Admin_User_Options (User_ID, Admin_Option_ID)
(select Distinct @User_ID,aaa.Admin_Option_ID
 from Admin_User_Options aaa)