<h3>Описание задания</h3>
На основе ежедневных данных о курсах валют ЦБ (https://www.cbr-xml-daily.ru/daily_json.js) необходимо создать Web-сервис с использованием ASP.Net Core, который реализует 2 API метода:

1. `GET /currencies` — должен возвращать список курсов валют с возможностью пагинации
2. `GET /currency/` — должен возвращать курс валюты для переданного идентификатора валюты

<h3>Как пользоваться</h3>

1. Для получения списка необходимо передать обязательные параметры: `pageNumber` - номер страницы, и `pageSize` - размер страницы (количество элементов за запрос, максимум - 5): `localhost:xxx/currencies?pageSize=x&pageNumber=x`
2. Для получения одного элемента необходимо передать обязательный параметр `id`: `localhost:xxx/currency?id=xxx`

Возвращать будет как в браузере, так и в postman.
