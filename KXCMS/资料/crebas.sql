/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     2013/8/15 15:39:16                           */
/*==============================================================*/


if exists (select 1
            from  sysobjects
           where  id = object_id('tblForum')
            and   type = 'U')
   drop table tblForum
go

if exists (select 1
            from  sysobjects
           where  id = object_id('tblMessage')
            and   type = 'U')
   drop table tblMessage
go

if exists (select 1
            from  sysobjects
           where  id = object_id('tblNavMenu')
            and   type = 'U')
   drop table tblNavMenu
go

if exists (select 1
            from  sysobjects
           where  id = object_id('tblPost')
            and   type = 'U')
   drop table tblPost
go

if exists (select 1
            from  sysobjects
           where  id = object_id('tblSystem')
            and   type = 'U')
   drop table tblSystem
go

if exists (select 1
            from  sysobjects
           where  id = object_id('tblUser')
            and   type = 'U')
   drop table tblUser
go

/*==============================================================*/
/* Table: tblForum                                              */
/*==============================================================*/
create table tblForum (
   ForumID              int                  identity,
   ForumName            nvarchar(100)        null,
   ForumIcon            nvarchar(1000)       null,
   PForumID             int                  null,
   ForumDescribe        nvarchar(Max)        null,
   constraint PK_TBLFORUM primary key (ForumID)
)
go

/*==============================================================*/
/* Table: tblMessage                                            */
/*==============================================================*/
create table tblMessage (
   MID                  int                  identity,
   MContent             nvarchar(Max)        null,
   MIP                  nvarchar(100)        null,
   MDate                datetime             null,
   MName                nvarchar(100)        null,
   constraint PK_TBLMESSAGE primary key (MID)
)
go

/*==============================================================*/
/* Table: tblNavMenu                                            */
/*==============================================================*/
create table tblNavMenu (
   NavID                int                  identity,
   NavName              nvarchar(100)        null,
   NavUrl               nvarchar(1000)       null,
   NavSort              int                  null,
   PNavID               int                  null,
   NavLayer             int                  null,
   constraint PK_TBLNAVMENU primary key (NavID)
)
go

/*==============================================================*/
/* Table: tblPost                                               */
/*==============================================================*/
create table tblPost (
   PostID               int                  identity,
   PostTitle            nvarchar(1000)       null,
   PostContent          nvarchar(Max)        null,
   PostDate             datetime             null,
   UserID               int                  null,
   UserName             nvarchar(100)        null,
   PostImage            nvarchar(Max)        null,
   ForumID              int                  null,
   ForumName            nvarchar(100)        null,
   constraint PK_TBLPOST primary key (PostID)
)
go

/*==============================================================*/
/* Table: tblSystem                                             */
/*==============================================================*/
create table tblSystem (
   SysID                int                  identity,
   ListPageSize         int                  null,
   IsRegCodeByPost      int                  null,
   IsRegCodeByMessage   int                  null,
   IsRegCodeByLogin     int                  null,
   IsLoginByMessage     int                  null,
   constraint PK_TBLSYSTEM primary key (SysID)
)
go

/*==============================================================*/
/* Table: tblUser                                               */
/*==============================================================*/
create table tblUser (
   UserID               int                  identity,
   UserName             nvarchar(100)        null,
   Password             nvarchar(100)        null,
   UserState            int                  null,
   UserCreateDate       datetime             null,
   RealName             nvarchar(100)        null,
   Sex                  nvarchar(100)        null,
   Age                  int                  null,
   RegIP                nvarchar(100)        null,
   Role                 int                  null,
   LastLoginDate        datetime             null,
   constraint PK_TBLUSER primary key (UserID)
)
go

