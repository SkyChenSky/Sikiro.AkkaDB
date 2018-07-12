# Sikiro.AkkaDB
This is a k/v database,which base on akka.net.I want to build a open sourse config center by this.

## Why port is 1218
It's my birthdate.

### Init AkkaDBClient
```c#
var akkaDBClient = new AkkaDBClient("localhost:1218");
```

### Set
```c#
akkaDBClient.Set(key, value);
```

### Get
```c#
akkaDBClient.Get(key);
```

### Remove
```c#
akkaDBClient.Remove(key
```

### Others
It is first version,it will update on day after day

## End
If you have good suggestions, please feel free to mention to me.

