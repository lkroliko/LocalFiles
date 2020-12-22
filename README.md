# Local Files via HTML links

## Problem
Browser are blocking links to local files on computer for security reasons.
Some systems are working on links to files stored on SMB server with user can't open in newer browser. This works on onl IE 11.

## Solution
Create new protocol "localfile".
Create program with will be handle that protocol and run requested file.
Change links from "file" to "localfile" on web page.

Jquery script:
```
$(document).ready(function() {
  $("a").each(function(i, a) {
    if(a.href.match("^file://")){				
      $(a).attr("href", a.href.replace("file://", "localfile:/"))
      }
    })
}); 
```

## Deployement
Install msi program via GPO

## Configuration
Configure using registry key HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\LocalFiles  
AclExtensions:  
  default value - .BAT;.BIN;.CMD;.COM;.CPL;.EXE;.GADGET;.INF1;.INS;.INX;.ISU;.JOB;.JSE;.LNK;.MSC;.MSI;.MSP;.MST;.PAF;.PIF;.PS1;.REG;.RGS;.SCR;.SCT;.SHB;.SHS;.U3P;.VB;.VBE;.VBS;.VBSCRIPT;.WS;.WSF;.WSH  
AclExtensionsType:  
  0 - AclExtension is a allow list  
  1 - AclExtension is a deny list  
  default value: 1  
AclPaths:  
  default value - empty, you need to add paths to allow opening files for example v:;d:  
 ";" - is separator
