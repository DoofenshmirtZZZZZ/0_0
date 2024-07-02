#include <iostream>
#include <fstream>
#include <string>
#include <regex>
#include "main.h"

using namespace std;


int main() {

  copy_file("CreateDB.sql", "1_Regexp_CreateDB.sql");

  do_regexp(regex(R"(GO)"));
  do_regexp(regex(R"(SET.+)"));
  do_regexp(regex(R"(\[\w+\]\.)"));
  do_regexp(regex(R"(\[)"));
  do_regexp(regex(R"(\])"));

  do_regexp(regex(R"(IDENTITY\(1,1\))"), "AUTO_INCREMENT");
  do_regexp(regex(R"(timestamp NOT NULL)"), "timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP");

  do_regexp(regex(R"(CONSTRAINT\s\w+\s)"));
  do_regexp(regex(R"(\sCLUSTERED)"));
  do_regexp(regex(R"(WITH \(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON\)\sON PRIMARY)"));
  
  do_regexp(regex(R"(\sNONCLUSTERED)"));
  do_regexp(regex(R"(UNIQUE)"), "UNIQUE KEY");

  do_regexp(regex(R"(\sON PRIMARY)"), ";");
  do_regexp(regex(R"(TEXTIMAGE_ON PRIMARY)")); 

  do_regexp(regex(R"(uniqueidentifier)"), "char(32)");
  do_regexp(regex(R"(xml)"), "text");
  do_regexp(regex(R"(ntext)"), "text");
  do_regexp(regex(R"(nvarchar(max))"), "text");

  do_regexp(regex(R"(image)"), "BLOB");
  do_regexp(regex(R"(varbinary(max))"), "BLOB");
  
  
  
  copy_file("2_Regexp_CreateDB.sql", "CreateDB_Regexp.sql");

  remove("1_Regexp_CreateDB.sql");
  remove("2_Regexp_CreateDB.sql");

  return 0;
}
