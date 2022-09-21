create database DTSMCC01;

create table Employee(
	EmployeeId int primary key,
	Name varchar (155) not null,
	Email varchar (50) unique not null
);

create table JenisCuti(
	IdJenisCuti int identity primary key,
	NamaJenisCuti varchar (50) not null
);

create table Konfirmasi(
	IdKonfirmasi int identity primary key,
	IdCuti int,
	Status varchar(50) not null default 'Belum Konfirmasi'
);

create table Cuti(
	IdCuti int primary key,
	EmployeeId int,
	IdJenisCuti int,
	StartDate Datetime not null,
	EndDate Datetime not null,
	Status Varchar (50) not null default 'Menunggu Konfirmasi',
	Foreign key (EmployeeId) References Employee(EmployeeId),
	Foreign key (IdJenisCuti) References JenisCuti(IdJenisCuti)
);