#include <fstream>
#include <string>
#include <regex>

using namespace std;


void copy_file(string read, string write) {
  ifstream file_read (read);
  ofstream file_write (write);

  if (file_read.is_open()) {
    string line;
    while (getline(file_read, line)) {
      file_write << line << endl;
    }
  }

  file_read.close();
  file_write.close();
}


void do_regexp(regex regexp, string change = "") {
  ifstream file_read ("1_Regexp_CreateDB.sql");
  ofstream file_write ("2_Regexp_CreateDB.sql");

  if (file_read.is_open()) {
    string line, new_line;
    while (getline(file_read, line)) {
      new_line = regex_replace(line, regexp, change);
      if (new_line != "") {
        file_write << new_line << endl;
      }
    }
  }

  file_read.close();
  file_write.close();

  
  copy_file("2_Regexp_CreateDB.sql", "1_Regexp_CreateDB.sql");
}
