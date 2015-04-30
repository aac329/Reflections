use Distance
go

ALTER TABLE Streaming_Encoder_Profile
ADD [Video_Framerate] [varchar] (10),
	[Video_Input_Size] [varchar] (20),
	[Audio_Bitrate] [int],
	[Server_Url] [varchar] (512),
	[Backup_Server_Url] [varchar] (512),
	[Internal_Encoder] [bit]

SELECT * FROM Streaming_Encoder_Profile;
	
	
	--This is the end of the Streaming_Encoder_Profile Updates
	
	
	
ALTER TABLE Streaming_Live_Event
ADD [Public] [bit],
	[Record] [bit]
	
SELECT * FROM Streaming_Live_Event;
	
	
	--This is the end of the Streaming_Live_event Updates
	
	
CREATE TABLE [Streaming_Encoder_Profile_Stream] (
	[Streaming_Encoder_Profile_Stream] [int] IDENTITY(1,1) NOT NULL,
	[Streaming_Encoder_Profile_ID] [int],
	[Video_Bitrate] [int],
	[Video_Height] [int],
	[Video_Width] [int],

PRIMARY KEY (Streaming_Encoder_Profile_Stream),

FOREIGN KEY (Streaming_Encoder_Profile_ID)
REFERENCES Streaming_Encoder_Profile(Streaming_Encoder_Profile_ID)
)

SELECT * FROM Streaming_Encoder_Profile_Stream;


		--This is the end of the create table statement