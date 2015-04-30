                  DECLARE @ec_id_type AS INTEGER

                  SELECT @ec_id_type = [Distance].[dbo].Person_Id_Type.id
                  FROM [Distance].[dbo].Person_Id_Type
                  WHERE  [Distance].[dbo].Person_Id_Type.description = 'Prospect ID';
                  
                  SELECT DISTINCT record1_id, record2_id, 
                  CASE WHEN record1_id < record2_id THEN record1_id ELSE record2_id END,
                  CASE WHEN record1_id > record2_id THEN record1_id ELSE record2_id END
                  FROM [Distance].[dbo].Person_Match_Comparison a
                  WHERE 
                  a.match_score <= 0.23
            AND (
                (a.match_score = 0.0 AND a.id > 0)
                OR (a.match_score > 0.0)
            )
                  AND ((a.match_score = 0.0
                  AND a.id > 0)
                  OR a.match_score > 0.0)
                  AND a.human_match IS NULL
                  AND a.human_match_date IS NULL --Used to skip a possible match without setting the human_match column.

                  AND a.record1_source_system = @ec_id_type AND a.record1_source_system = a.record2_source_system --Used to limit us to prospect to prospect comparisons.

                  AND NOT EXISTS (SELECT 0 FROM [Distance].[dbo].Prospect_Employee_Process aa
                                          WHERE aa.Prospect_ID = a.record1_id AND aa.Effective_Status = 'I')
                  AND NOT EXISTS (SELECT 0 FROM [Distance].[dbo].Prospect_Employee_Process ab
                                          WHERE ab.Prospect_ID = a.record2_id AND ab.Effective_Status = 'I')
                  GROUP BY record1_id, record2_id