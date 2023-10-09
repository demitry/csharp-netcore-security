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