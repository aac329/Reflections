UPDATE PR
SET PR.Referred = 'N'
FROM distance.dbo.Prospect_Referred PR LEFT JOIN Distance.dbo.Prospect_Override PO ON PR.Prospect_ID = PO.Prospect_ID
WHERE PO.Prospect_Override_Reason_ID = 35
AND PO.Prospect_Override_Reason_ID <> 63
AND PR.Referred = 'Y';