# Pierres Treats

  

## By **Dominique Youmans**

  
  
  

### Description

  

New treats tracking application that uses user authentication and a many-to-many relationship.
  

### Sql Installation

  

**MacOS**

 1. Download the **MySQL Community Server** DMG File from the **MySQL
    Community Server** page. Click the download icon Use the No thanks,
    just start my download link.

  

 2. Follow along with the Installer until you reach the Configuration
    page. Once you've reached Configuration, select or set the following
    options (use default if not specified):

  

 3. Use Legacy Password Encryption.
 4. Set password to epicodus. You can use your own password if you want
    but epicodus will be assumed in the lessons.
    
    Click Finish.
 5. Open the terminal and enter the command:
		`echo 'export
        PATH="/usr/local/mysql/bin:$PATH"' >> ~/.bash_profile`

	

	

 1. Next, type in `source ~/.bash_profile` (or restart the terminal) in
    order to actually verify that **MySQL** was installed.
 2. Verify **MySQL** installation by opening terminal and entering the
    command `mysql -uroot -pepicodus` You'll know it's working and
    connected if you gain access and see the **MySQL** command line. If it's
    not working, you'll likely get a `-bash: mysql: command not found`
    error. You can exit the program by entering `exit`.

  

 1. Download the ***MySQL Workbench DMG*** File from the ***MySQL Workbench*** page.
    (Use the No thanks, just start my download link.)

  

 1. Install **MySQL Workbench** to Applications folder.

  

 1. Open **MySQL Workbench** and select the Local instance 3306 server. You
    will need to enter the password you set. (We used epicodus.) If it
    connects, you're all set.

  

**Windows 10**

 1. Download the **MySQL Web Installer** from the **MySQL Downloads** page. (Use
    the No thanks, just start my download link.)

  

 1. Follow along with the installer: Click **Yes** if prompted to update.
 2. Accept license terms.
 3. Choose Custom setup type.
 4. When prompted to Select Products and Features, choose the following: **MySQL Server** (Will be under **MySQL Servers**), **MySQL Workbench** (Will be under Applications), 
 5. Select Next, then Execute. Wait for download and installation. (This
    can take a few minutes.)
 6. Advance through Configuration as follows: High Availability set to Standalone, Defaults are OK under Type and Networking, Authentication Method set to Use Legacy Authentication Method.
 7. Set password to epicodus. You can use your own if you want but
    epicodus will be assumed in this repo.
 8. Unselect Configure **MySQL Server** as a Windows Service.
 9. Complete Installation process.
 10. Add the **MySQL** environment variable to the System PATH. We must
     include **MySQL** in the System Environment Path Variable. This is its
     own multi-step process. Instructions here are for Windows 10:
 11. Open the Control Panel and visit System > Advanced System Settings
     -> Environment Variables...
 12. Then select PATH..., click Edit..., then Add.
 13. Add the exact location of your **MySQL** installation, and click OK.
     (This location is likely C:\Program Files\MySQL\MySQL Server
     8.0\bin, but may differ depending on your specific installation.)
 14. Verify installation by opening Windows PowerShell and entering the
     command `mysql -uroot -pepicodus`. You'll know it's working and
     connected if you gain access and see **MySQL**'s command line. You can exit the mysql program by entering exit.

  

 1. Open **MySQL Workbench** and select the Local instance 3306 server (it  
    may have a different name). You will need to enter the password you 
    set (We used epicodus). If it connects, you're all set.

  


  

  

  
  

### Specs

|Behavior| Input | Output |

|--|--|--|


  
  
  
  
  

### Known Bugs

  

Database connection issues.

  

### Support Details

  

If you run into any issues running this application, please contact Dominique Youmans at ddyoumans@icloud.com.

  

### Technologies Used

  

-  [x] .NET

-  [x] C#

-  [x] HTML

-  [x] CSS

  
  

### License

  

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

  

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

  

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NON-INFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

  

Copyright (c) 2020 **_Dominique Youmans_**