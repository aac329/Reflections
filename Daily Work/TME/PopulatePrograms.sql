INSERT INTO [Distance].[dbo].[Tme_Program]
           ([Title]
           ,[Program_Scope]
           ,[Status])
     VALUES
           ('Administrative Pages'
           ,'All applications accessable on the admin.extended.nau.edu Web site'
           ,'A')
UPDATE [Distance].[dbo].[Tme_Project]
   SET [Program_ID] = 1
 WHERE [Project_ID] in (76,77,78,80,81,82,83,84,85,86,87,88,97,108,116,220,231,236,243,261,278,328,331,338,343,347,350)


INSERT INTO [Distance].[dbo].[Tme_Program]
           ([Title]
           ,[Program_Scope]
           ,[Status])
     VALUES
           ('Personalized Learning'
           ,'All applications on all Web sites directly supporting the Personalized Learning Program'
           ,'A')
UPDATE [Distance].[dbo].[Tme_Project]
   SET [Program_ID] = 2
 WHERE [Project_ID] in (225,227,239,240,247,248,264,272,322,334,353,355)
