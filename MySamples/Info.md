## XSS [2]

Inspect and check the html:

```html
	<div class="col-md-12">
        Your search for <i><script>alert('Hacked!')</script></i> did not yield any results.
    </div>
```


With controller it works via url:

http://localhost:12345/Home/SearchAPI?searchTerm=<script>alert('Hacked!')</script>

http://localhost:5239/Home/SearchAPI?searchTerm=%3Cscript%3Ealert(%27Hacked!%27)%3C/script%3E

```json
[
    "<script>alert('Hacked!')</script> 1",
    "<script>alert('Hacked!')</script> 2",
    "<script>alert('Hacked!')</script> 3"
]

```

## Sessions [3]

Copy Session Cookie Chrome->Application->Cookies and get the info with another browser

```
http://localhost:5240/

.AspNetCore.Session

CfDJ8B0ZwGv6A5tKpyoiQ1t3CFhDODUolONWx7pmfeq3uKSxFjJoFklFwXvVPB64YPHoxzQp67jiy7GqioX4QV8kuB%2BFbZ80xwfBrAtNhbZSfbxGMjzVXxXITN8zc3MsyXn49uUrFbTWzJ%2BZXmShhLA1NykCoJxkrsMFOvfJZgeENxfL
```

  
```cs
builder.Services.AddSession(options => {  
	options.Cookie.HttpOnly = true;  
	options.Cookie.SecurePolicy = CookieSecurePolicy.Always;  
});
```

Check document.cookie in console
It is empty
