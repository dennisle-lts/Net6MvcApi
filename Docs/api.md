# User API

- [User API](#user-api)
  - [Create User](#create-user)
    - [Create User Request](#create-user-request)
    - [Create User Response](#create-user-response)

## Create User

### Create User Request
```js
POST /users
```

```json
{
    "name": "john doe",
    "email": "jdoe@gmail.com",
    "dateOfBirth": "2022-01-01T01:00:00"
}
```

### Create User Response

```js
201 Created
```

```yml
Location: {{host}}/User/{{id}}
```

```json
{
    "id": "00000000-0000-0000-0000-000000000000",
    "name": "Vegan Sunshine",
    "description": "Vegan everything! Join us for a healthy breakfast..",
    "startDateTime": "2022-04-08T08:00:00",
    "endDateTime": "2022-04-08T11:00:00",
    "lastModifiedDateTime": "2022-04-06T12:00:00",
    "savory": [
        "Oatmeal",
        "Avocado Toast",
        "Omelette",
        "Salad"
    ],
    "Sweet": [
        "Cookie"
    ]
}
```