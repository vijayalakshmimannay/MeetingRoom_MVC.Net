use MeetingRoom
Create table tbl_EmployeeReg(        
    EmployeeId int IDENTITY(1,1) NOT NULL,        
    Email varchar(20) NOT NULL,        
    Password varchar(20) NOT NULL
)

select *from tbl_EmployeeReg
select *from tbl_Role
select *from tbl_MeetingRoomAvailability

insert into tbl_Role (Role) values ('BranchManager')

ALTER TABLE tbl_EmployeeReg
ADD BranchName varchar(255);
ALTER TABLE tbl_EmployeeReg ADD PRIMARY KEY (EmployeeId)
ALTER TABLE tbl_EmployeeReg ADD RoleId int
ALTER TABLE tbl_EmployeeReg ADD FOREIGN KEY (RoleId) references tbl_Role (RoleId)

Create Table tbl_Role (
RoleId int IDENTITY (1,1) PRIMARY KEY NOT NULL,
Role varchar(20) NOT NULL)


Go
create or alter procedure [dbo].[Meeting_usp_Employee]  
(  
@Email varchar(20)=NULL,  
@Password varchar(20)=NULL,  
@BranchName varchar(255)=NULL,
@RoleId int
)
as  
begin  
insert into tbl_EmployeeReg(Email,Password,BranchName,RoleId)values(@Email,@Password,@BranchName,@RoleId)  
end  

Go
create or alter procedure [dbo].[Meeting_usp_EmployeeLogin]  
(  
@Email varchar(20)=NULL,  
@Password varchar(20)=NULL
)
as  
begin  
select Email from tbl_EmployeeReg where Email=@Email and Password=@Password
end  

Create table tbl_MeetingRequest(        
    Request_Id int IDENTITY(1,1) NOT NULL,        
    UserId int, 
	FOREIGN KEY (UserId) REFERENCES tbl_EmployeeReg(EmployeeId),
    StartTime Varchar(50),
	EndTime varchar(50),
	MDate varchar(100),
	Purpose varchar(150),
	RequestFor varchar(100),
	NoOfEmps int,
	MeetingRoom_Id int,
	ReqStatus varchar(20) NOT NULL
)
select *from tbl_MeetingRequest


insert into tbl_MeetingRequest(UserId,StartTime,EndTime,MDate,Purpose,RequestFor,NoOfEmps,MeetingRoom_Id,ReqStatus)values(1,'10:10:23','11:20:43','2023-02-03','ProjectMeeting','Meeting',10,2,'Accept')


Create table tbl_MeetingRoomAvailability(        
    MeetingRoom_Id int IDENTITY(1,1) NOT NULL,        
    FloorNo int, 
	RoomNo int, 
	Desktops int,
	Projectors int,
	Capacity int)

select *from tbl_MeetingRoomAvailability	

insert into tbl_MeetingRoomAvailability(FloorNo,RoomNo,Desktops,Projectors,Capacity)values(1,100,10,2,15)

Create or alter procedure spGetAllMeetingRooms      
as      
Begin      
    select * from tbl_MeetingRoomAvailability      
End  

Go
create or alter procedure [dbo].[MeetingRequest]  
( 
@UserId int,
@MeetingRoom_Id int,
@StartTime varchar(20)=NULL,  
@EndTime varchar(20)=NULL,  
@Mdate varchar(255)=NULL,
@Purpose varchar(255)=NULL,
@RequestFor varchar(255)=NULL,
@NoOfEmps int
)
as  
begin  
insert into tbl_MeetingRequest(UserId,StartTime,EndTime,Mdate,Purpose,RequestFor,NoOfEmps,MeetingRoom_Id)values(@UserId,@StartTime,@EndTime,@Mdate,@Purpose,@RequestFor,@NoOfEmps,@MeetingRoom_Id)  
end  
