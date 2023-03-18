CREATE TABLE IF NOT exists public."Users"{
	"Id" serial4 NOT NULL,
	"FirstName" varchar(30) NOT NULL,
	"LastName" varchar(30) NOT NULL,
	"Email" varchar(50) NULL,
	"TaskId" int NOT NULL GENERATED ALWAYS AS IDENTITY

};

CREATE TABLE IF NOT exists public."Tasks"{
	"Id" serial4 NOT NULL,
	"Subject" varchar(80) NOT NULL,
	"Description" varchar(80) NOT NULL,
	"UserId" int NOT NULL GENERATED ALWAYS AS IDENTITY
};