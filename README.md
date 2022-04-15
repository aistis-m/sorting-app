
# Sorting App

App takes space separated number string (eg. 1 2 3), and returns sorted result 



## Local Web server

To start the service run below command from root directory

```bash
  dotnet run
```


## API Reference

#### Sort numbers

```http
  POST http://localhost:8080/sort
```

| Parameter | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `raw` | `string` | **Required**. String of integers |

#### Get latest sort result

```http
  GET http://localhost:8080/result
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `--`      | `--` |-- |




