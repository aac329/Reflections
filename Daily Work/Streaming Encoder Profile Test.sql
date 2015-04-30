ALTER TABLE Streaming_Encoder_Profile 
ADD [Video_Framerate] [varchar] (10),
	[Video_Input_Size] [varchar] (20),
	[Audio_Bitrate] [int],
	[Server_Url] [varchar] (512),
	[Backup_Server_Url] [varchar] (512),
	[Internal_Encoder] [bit]