use Test_DB
GO

--Drop tables
drop table if exists TestData
drop table if exists TestData_2
GO

--Create a table with 40+ columns
create table TestData
(
	[ID]				bigint primary key,
	[Name]				nvarchar(200),
	[Age]				int,
	[Email]				nvarchar(100),
	[Date_of_Birth]		date,
	[Is_Active]			bit,
	[Sample_Column_1]	nvarchar(200) default('Some Test Value - ' + convert(nvarchar, convert(int, convert (varbinary(4), NEWID(), 1)))),
	[Sample_Column_2]	nvarchar(200) default('Some Test Value - ' + convert(nvarchar, convert(int, convert (varbinary(4), NEWID(), 1)))),
	[Sample_Column_3]	nvarchar(200) default('Some Test Value - ' + convert(nvarchar, convert(int, convert (varbinary(4), NEWID(), 1)))),
	[Sample_Column_4]	nvarchar(200) default('Some Test Value - ' + convert(nvarchar, convert(int, convert (varbinary(4), NEWID(), 1)))),
	[Sample_Column_5]	nvarchar(200) default('Some Test Value - ' + convert(nvarchar, convert(int, convert (varbinary(4), NEWID(), 1)))),
	[Sample_Column_6]	nvarchar(200) default('Some Test Value - ' + convert(nvarchar, convert(int, convert (varbinary(4), NEWID(), 1)))),
	[Sample_Column_7]	nvarchar(200) default('Some Test Value - ' + convert(nvarchar, convert(int, convert (varbinary(4), NEWID(), 1)))),
	[Sample_Column_8]	nvarchar(200) default('Some Test Value - ' + convert(nvarchar, convert(int, convert (varbinary(4), NEWID(), 1)))),
	[Sample_Column_9]	nvarchar(200) default('Some Test Value - ' + convert(nvarchar, convert(int, convert (varbinary(4), NEWID(), 1)))),
	[Sample_Column_11]	nvarchar(200) default('Some Test Value - ' + convert(nvarchar, convert(int, convert (varbinary(4), NEWID(), 1)))),
	[Sample_Column_12]	nvarchar(200) default('Some Test Value - ' + convert(nvarchar, convert(int, convert (varbinary(4), NEWID(), 1)))),
	[Sample_Column_13]	nvarchar(200) default('Some Test Value - ' + convert(nvarchar, convert(int, convert (varbinary(4), NEWID(), 1)))),
	[Sample_Column_14]	nvarchar(200) default('Some Test Value - ' + convert(nvarchar, convert(int, convert (varbinary(4), NEWID(), 1)))),
	[Sample_Column_15]	nvarchar(200) default('Some Test Value - ' + convert(nvarchar, convert(int, convert (varbinary(4), NEWID(), 1)))),
	[Sample_Column_16]	nvarchar(200) default('Some Test Value - ' + convert(nvarchar, convert(int, convert (varbinary(4), NEWID(), 1)))),
	[Sample_Column_17]	nvarchar(200) default('Some Test Value - ' + convert(nvarchar, convert(int, convert (varbinary(4), NEWID(), 1)))),
	[Sample_Column_18]	nvarchar(200) default('Some Test Value - ' + convert(nvarchar, convert(int, convert (varbinary(4), NEWID(), 1)))),
	[Sample_Column_19]	nvarchar(200) default('Some Test Value - ' + convert(nvarchar, convert(int, convert (varbinary(4), NEWID(), 1)))),
	[Sample_Column_101]	nvarchar(200) default('Some Test Value - ' + convert(nvarchar, convert(int, convert (varbinary(4), NEWID(), 1)))),
	[Sample_Column_102]	nvarchar(200) default('Some Test Value - ' + convert(nvarchar, convert(int, convert (varbinary(4), NEWID(), 1)))),
	[Sample_Column_103]	nvarchar(200) default('Some Test Value - ' + convert(nvarchar, convert(int, convert (varbinary(4), NEWID(), 1)))),
	[Sample_Column_104]	nvarchar(200) default('Some Test Value - ' + convert(nvarchar, convert(int, convert (varbinary(4), NEWID(), 1)))),
	[Sample_Column_105]	nvarchar(200) default('Some Test Value - ' + convert(nvarchar, convert(int, convert (varbinary(4), NEWID(), 1)))),
	[Sample_Column_106]	nvarchar(200) default('Some Test Value - ' + convert(nvarchar, convert(int, convert (varbinary(4), NEWID(), 1)))),
	[Sample_Column_107]	nvarchar(200) default('Some Test Value - ' + convert(nvarchar, convert(int, convert (varbinary(4), NEWID(), 1)))),
	[Sample_Column_108]	nvarchar(200) default('Some Test Value - ' + convert(nvarchar, convert(int, convert (varbinary(4), NEWID(), 1)))),
	[Sample_Column_109]	nvarchar(200) default('Some Test Value - ' + convert(nvarchar, convert(int, convert (varbinary(4), NEWID(), 1)))),
	[Sample_Column_1001]	nvarchar(200) default('Some Test Value - ' + convert(nvarchar, convert(int, convert (varbinary(4), NEWID(), 1)))),
	[Sample_Column_1002]	nvarchar(200) default('Some Test Value - ' + convert(nvarchar, convert(int, convert (varbinary(4), NEWID(), 1)))),
	[Sample_Column_1003]	nvarchar(200) default('Some Test Value - ' + convert(nvarchar, convert(int, convert (varbinary(4), NEWID(), 1)))),
	[Sample_Column_1004]	nvarchar(200) default('Some Test Value - ' + convert(nvarchar, convert(int, convert (varbinary(4), NEWID(), 1)))),
	[Sample_Column_1005]	nvarchar(200) default('Some Test Value - ' + convert(nvarchar, convert(int, convert (varbinary(4), NEWID(), 1)))),
	[Sample_Column_1006]	nvarchar(200) default('Some Test Value - ' + convert(nvarchar, convert(int, convert (varbinary(4), NEWID(), 1)))),
	[Sample_Column_1007]	nvarchar(200) default('Some Test Value - ' + convert(nvarchar, convert(int, convert (varbinary(4), NEWID(), 1)))),
	[Sample_Column_1008]	nvarchar(200) default('Some Test Value - ' + convert(nvarchar, convert(int, convert (varbinary(4), NEWID(), 1)))),
	[Sample_Column_1009]	nvarchar(200) default('Some Test Value - ' + convert(nvarchar, convert(int, convert (varbinary(4), NEWID(), 1))))
)
GO

--Populate dummy data in this table (for 1 million records)
DECLARE @values TABLE (DataValue int, RandValue INT)

;WITH mycte AS
(
SELECT 1 DataValue
UNION all
SELECT DataValue + 1
FROM    mycte   
WHERE   DataValue + 1 <= 1000000
)
INSERT INTO @values(DataValue,RandValue)
SELECT 
        DataValue,
        convert(int, convert (varbinary(4), NEWID(), 1)) AS RandValue
FROM mycte m 
OPTION (MAXRECURSION 0)


insert into TestData(ID, Name, Age, Email, Date_of_Birth, Is_Active)
SELECT 
        v.DataValue,
        'Name' + convert(nvarchar, abs(v.RandValue)),
		convert(int, convert (varbinary(1), NEWID(), 1)) % 100,
		convert(nvarchar, v.DataValue) + '@test.com',
		DATEADD(DAY, RAND(CHECKSUM(NEWID()))*(1+DATEDIFF(DAY, '1-Jan-1950', '30-Dec-2012')),'1-Jan-1950'),
		convert(int, convert (varbinary(1), NEWID(), 1)) % 2
FROM    @values v

--Create the 2nd table with same data
select * into dbo.TestData_2 from TestData 


--Create some differences in data for some records
--Record 1 has different Age and Is_Active values
update TestData set Age = 44, Is_Active = 0 where ID = 1
update TestData_2 set Age = 45, Is_Active = 1 where ID = 1

--Record 9652 has different date of birth
update TestData_2 set Date_of_Birth = '6-Mar-1982' where ID = 9652

--Records 6 to 12 have different Sample_Column_7 values
update TestData_2 set Sample_Column_7 = 'Some new value' where ID  between 6 and 12

--Records 13 to 16 have different Sample_Column_8 values (null in one table)
update TestData_2 set Sample_Column_8 = null where ID  between 13 and 16

--Record 5412 does not exist in table 1
delete from TestData where ID = 5412

--Record 6666 does not exist in table 2
delete from TestData_2 where ID = 6666

----If you want to see the data
--select * from TestData order by 1
--select * from TestData_2 order by 1

