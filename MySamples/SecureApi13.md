## IdentityServer project

```
dotnet new install Duende.IdentityServer.Templates
```

```
Success: Duende.IdentityServer.Templates::6.3.1 installed the following templates:
Template Name                                               Short Name   
----------------------------------------------------------  -------------
Duende BFF Host using a Remote API                          bff-remoteapi
Duende BFF using a Local API                                bff-localapi 
Duende IdentityServer Empty                                 isempty      
Duende IdentityServer Quickstart UI (UI assets only)        isui         
Duende IdentityServer with ASP.NET Core Identity            isaspid      
Duende IdentityServer with Entity Framework Stores          isef         
Duende IdentityServer with In-Memory Stores and Test Users  isinmem      
```

project Duende IdentityServer Empty

## WebApi client project

### Trust certificate

- NET::ERR_CERT_INVALID
- https://support.google.com/chrome/answer/6098869#-207

As admin:

```
dotnet dev-certs https --trust
```

Check certmgr.msc

https://stackoverflow.com/questions/63796566/neterr-cert-authority-invalid-in-asp-net-core

for me executing "dotnet dev-certs https --trust" in command line as admin solved the problem

```
Running the command dotnet dev-certs https --trust will create a self-signed certificate in your device. This certificate will be issued to the localhost domain. In my case, after running it, the certificate was created but it was not added to "Trusted Root Certification Authorities".

To add the certificate, you will need to open certmgr.msc (win+r and run certmgr.msc), then go to "Personal" certificates and export the .cer certificate issued to localhost with the correct expiration time.

If you cannot find the certificate there, you can go to the browser and click on the not secure connection icon, then open the invalid certificate and go to the Details tab and click "Copy to File...", which should create also a .cer certificate.

Next, go to "Trusted Root Certification Authorities" and import the certificate there. Once that is done, the certificate will be valid in your local machine. You may need to restart the browser and the service.
```