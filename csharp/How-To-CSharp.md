How to deal with CSharp project
-
Works only with words in json templates that can be found in LANG folder!

To get the os language, just do that:
```cs
Languages languages = new Languages();
_a_control.Text = languages.TryGet("file");
```

To force another language, just do that:
```cs
Languages languages = new Languages("fr-fr");
_a_control.Text = languages.TryGet("file");
```
