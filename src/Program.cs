var startTime = DateTime.Now; 
var endTime = DateTime.Now;

DataTable dataTable_1, dataTable_2;

//Show Header
AnsiConsole.MarkupLine("[bold yellow]Welcome to a cool utility to find differences in data between TWO SQL TABLES![/]".ToUpper());
AnsiConsole.MarkupLine("[bold yellow]=============================================================================[/]");
AnsiConsole.WriteLine();
AnsiConsole.WriteLine();

AnsiConsole.MarkupLine("[red]This tool only connects to Microsoft SQL Server using Windows Authentication[/] [italic](SQL Authentication is coming soon)[/]");
AnsiConsole.WriteLine();

//Get Server 1 Details
var serverName_1 = AnsiConsole.Prompt<string>(
    new TextPrompt<string>("What is the name of [#336699]SQL Server 1[/]?")
        .PromptStyle("white")
        );

var databaseName_1 = AnsiConsole.Prompt<string>(
    new TextPrompt<string>("In which [#336699]database[/] does the table reside?")
        .PromptStyle("white")
        );

var tableName_1 = AnsiConsole.Prompt<string>(
    new TextPrompt<string>("What is the [#336699]table[/] name?")
        .PromptStyle("white")
        );

//Display a blank line
AnsiConsole.WriteLine();

//Get Server 2 Details
var serverName_2 = AnsiConsole.Prompt<string>(
    new TextPrompt<string>("What is the name of [green]SQL Server 2[/]?")
        .PromptStyle("white")
        );

var databaseName_2 = AnsiConsole.Prompt<string>(
    new TextPrompt<string>("In which [green]database[/] does the table reside?")
        .PromptStyle("white")
        );

var tableName_2 = AnsiConsole.Prompt<string>(
    new TextPrompt<string>("What is the [green]table[/] name?")
        .PromptStyle("white")
        );

//Display a blank line
AnsiConsole.WriteLine();

//Get Column Details
var primaryKeyName = AnsiConsole.Prompt<string>(
    new TextPrompt<string>("What is the [blue]PRIMARY KEY[/] in these tables?")
        .PromptStyle("white")
        );

var columnsToCheck = AnsiConsole.Prompt<string>(
    new TextPrompt<string>("Which [blue]COLUMNS[/] should be compared in these tables [grey](comma separated list)[/]?")
        .PromptStyle("white")
        );

////TODO: Remove dummy data
//serverName_1 = "BAH-Home-Dev";
//serverName_2 = "BAH-Home-Dev";
//databaseName_1 = "Test_DB";
//databaseName_2 = "Test_DB";
//tableName_1 = "TestData";
//tableName_2 = "TestData_2";
//primaryKeyName = "ID";
//columnsToCheck = "Name, Age, Email, Date_of_Birth, Is_Active, Sample_Column_1, Sample_Column_2, Sample_Column_3, Sample_Column_4, Sample_Column_5, Sample_Column_6, Sample_Column_7, Sample_Column_8, Sample_Column_9, Sample_Column_11, Sample_Column_12, Sample_Column_13, Sample_Column_14, Sample_Column_15, Sample_Column_16, Sample_Column_17, Sample_Column_18, Sample_Column_19, Sample_Column_101, Sample_Column_102, Sample_Column_103, Sample_Column_104, Sample_Column_105, Sample_Column_106, Sample_Column_107, Sample_Column_108, Sample_Column_109, Sample_Column_1001, Sample_Column_1002, Sample_Column_1003, Sample_Column_1004, Sample_Column_1005, Sample_Column_1006, Sample_Column_1007, Sample_Column_1008, Sample_Column_1009";


//Display a blank line
AnsiConsole.WriteLine();
AnsiConsole.WriteLine();

//Show information provided
AnsiConsole.MarkupLine("[bold yellow]Please confirm if the information provided is correct?[/]");
AnsiConsole.Write(new Table().AddColumns("[bold grey]Question[/]", "[bold yellow]Answer[/]")
    .RoundedBorder()
    .BorderColor(Color.Grey)
    .AddRow("[grey]Server 1[/]", serverName_1)
    .AddRow("[grey]Database 1[/]", databaseName_1)
    .AddRow("[grey]Table 1[/]", tableName_1)
    .AddRow("", "")
    .AddRow("[grey]Server 2[/]", serverName_2)
    .AddRow("[grey]Database 2[/]", databaseName_2)
    .AddRow("[grey]Table 2[/]", tableName_2)
    .AddRow("", "")
    .AddRow("[grey]Primary Key[/]", primaryKeyName)
    .AddRow("[grey]Columns to compare[/]", columnsToCheck)
    );


//Display a blank line
AnsiConsole.WriteLine();

//Ask for confirmation
var confirmation = AnsiConsole.Confirm("[red]Do you want to continue?[/]");

//Display a blank line
AnsiConsole.WriteLine();
AnsiConsole.WriteLine();

//Exit the app if user says NO
if (!confirmation)
{
    AnsiConsole.MarkupLine("[yellow]No problem. See you next time. Have a good day![/]");
    return;
}

//Users wanted to continue, so here we go

//Prepare Connection Strings
var connString_1 = $"server={serverName_1};database={databaseName_1};Trusted_Connection=True;TrustServerCertificate=True;";
var connString_2 = $"server={serverName_2};database={databaseName_2};Trusted_Connection=True;TrustServerCertificate=True;";

//Prepare SQL Queries
var sqlQuery_1 = $"SELECT {primaryKeyName}, {columnsToCheck} FROM {tableName_1}";
var sqlQuery_2 = $"SELECT {primaryKeyName}, {columnsToCheck} FROM {tableName_2}";

//Display a blank line
AnsiConsole.WriteLine();
AnsiConsole.WriteLine();

//Show Waiting message
AnsiConsole.MarkupLine($"[bold green]Sit back and relax, while we do our magic![/]");

//Display a blank line
AnsiConsole.WriteLine();
AnsiConsole.WriteLine();


//Open the connection to server 1 and read the data table
try
{
    AnsiConsole.MarkupLine($"[yellow]Starting to read data from {serverName_1}.{databaseName_1}.{tableName_1}...[/]");
    startTime = DateTime.Now;
    dataTable_1 = await DB_Helpers.GetDataTableAsync(connString_1, sqlQuery_1);
    endTime = DateTime.Now;
    AnsiConsole.MarkupLine($"[bold green]{dataTable_1.Rows.Count}[/] rows read in {(endTime-startTime).TotalMilliseconds} milliseconds.");
}
catch (Exception ex)
{
    AnsiConsole.MarkupLine($"[red]An error occured while fetching data from Server 1 ({serverName_1}): {ex.Message}[/]");
    return;
}

//Display a blank line
AnsiConsole.WriteLine();

//Open the connection to server 2 and read the data table
try
{
    AnsiConsole.MarkupLine($"[yellow]Starting to read data from {serverName_2}.{databaseName_2}.{tableName_2}...[/]");
    startTime = DateTime.Now;
    dataTable_2 = await DB_Helpers.GetDataTableAsync(connString_2, sqlQuery_2);
    endTime = DateTime.Now;
    AnsiConsole.MarkupLine($"[bold green]{dataTable_2.Rows.Count}[/] rows read in {(endTime - startTime).TotalMilliseconds} milliseconds.");
}
catch (Exception ex)
{
    AnsiConsole.MarkupLine($"[red]An error occured while fetching data from Server 1 ({serverName_1}): {ex.Message}[/]");
    return;
}

//Convert data tables to dictionaries
var dict_1 = dataTable_1.AsEnumerable().ToDictionary(row => row.Field<dynamic>(primaryKeyName), row => row);
var dict_2 = dataTable_2.AsEnumerable().ToDictionary(row => row.Field<dynamic>(primaryKeyName), row => row);

//Display a blank line
AnsiConsole.WriteLine();
AnsiConsole.WriteLine();

//Find records in Table 1 that are not in Table 2
AnsiConsole.MarkupLine($"[yellow]Starting to find records from {serverName_1}.{databaseName_1}.{tableName_1} which are missing in {serverName_2}.{databaseName_2}.{tableName_2}...[/]");
startTime = DateTime.Now;
var recordsInTable1NotInTable2 = dict_1.Keys.Except(dict_2.Keys).Select(key => dict_1[key]).ToList();
endTime = DateTime.Now;
AnsiConsole.MarkupLine($"[bold red]{recordsInTable1NotInTable2.Count}[/] rows found in {(endTime - startTime).TotalMilliseconds} milliseconds, with Record IDs:");

//Display the record IDs
foreach (var record in recordsInTable1NotInTable2)
{
    AnsiConsole.MarkupLine($"[red]{primaryKeyName}: {(record as DataRow).Field<dynamic>(primaryKeyName)}[/]");
}

//Display a blank line
AnsiConsole.WriteLine();
AnsiConsole.WriteLine();

//Find records in Table 2 that are not in Table 1
AnsiConsole.MarkupLine($"[yellow]Starting to find records from {serverName_2}.{databaseName_2}.{tableName_2} which are missing in {serverName_1}.{databaseName_1}.{tableName_1}...[/]");
startTime = DateTime.Now;
var recordsInTable2NotInTable1 = dict_2.Keys.Except(dict_1.Keys).Select(key => dict_2[key]).ToList();
endTime = DateTime.Now;
AnsiConsole.MarkupLine($"[bold red]{recordsInTable2NotInTable1.Count}[/] rows found in {(endTime - startTime).TotalMilliseconds} milliseconds, with Record IDs:");

//Display the record IDs
foreach (var record in recordsInTable2NotInTable1)
{
    AnsiConsole.MarkupLine($"[red]{primaryKeyName}: {(record as DataRow).Field<dynamic>(primaryKeyName)}[/]");
}

//Display a blank line
AnsiConsole.WriteLine();
AnsiConsole.WriteLine();

//Find records that are in both tables but have different data
AnsiConsole.MarkupLine($"[yellow]Starting to find records between {serverName_1}.{databaseName_1}.{tableName_1} and {serverName_2}.{databaseName_2}.{tableName_2} which have different data...[/]");
startTime = DateTime.Now;
var recordsWithDifferentData = dict_1.Keys.Intersect(dict_2.Keys).Where(key => !(dict_1[key] as DataRow).ItemArray.SequenceEqual((dict_2[key] as DataRow).ItemArray)).Select(key => new { Key = key, Table1 = dict_1[key], Table2 = dict_2[key] }).ToList();
endTime = DateTime.Now;
AnsiConsole.MarkupLine($"[bold red]{recordsWithDifferentData.Count}[/] rows found in {(endTime - startTime).TotalMilliseconds} milliseconds with different data:");

//Display the differences with record IDs and column names and values
foreach (var record in recordsWithDifferentData)
{
    AnsiConsole.WriteLine();
    AnsiConsole.MarkupLine($"[red]{primaryKeyName}: {record.Key}[/]");
    foreach (DataColumn column in dataTable_1.Columns)
    {
        if (!(record.Table1[column.ColumnName].Equals(record.Table2[column.ColumnName])))
        {
            AnsiConsole.MarkupLine($"[white]{column.ColumnName}[/]: [grey]{record.Table1[column.ColumnName]}[/] [grey]=>[/] [grey]{record.Table2[column.ColumnName]}[/]");
        }
    }
}

//Display a blank line
AnsiConsole.WriteLine();
AnsiConsole.WriteLine();

AnsiConsole.MarkupLine("[yellow]And we are done. Have a good day! Press ENTER to exit.[/]");
Console.ReadLine();
