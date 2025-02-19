# Примеры HTTP запросов в браузере
# Все интерфейсы, устройства, регистры
http://127.0.0.1:9999/?json={"Method":"GET_ALL","TableName":"INTERFACE"}
# Обновить регистр
http://127.0.0.1:9999/?json={"Entity":{"DeviceId":3,"Name":"Новое имя","Description":"Новое описание","Values":[],"Id":8,"Timestamp":"2025-02-19T01:58:53.6089372"},"Method":"PUT","TableName":"REGISTER"}
# Удалить устройство
http://127.0.0.1:9999/?json={"Entity":{"InterfaceId":1,"Name":"Девайсs 0","Description":"Описsание девайса 0","IsEnabled":true,"FigureType":2,"Size":37,"PosX":6,"PosY":9,"Color":-11258248,"Registers":[{"DeviceId":1,"Name":"Регистрee 0","Description":"Описание регистра 0","Values":[],"Id":1,"Timestamp":"2025-02-19T01:58:53.6088271"},{"DeviceId":1,"Name":"Регистр 1","Description":"Описание регистра 1","Values":[],"Id":2,"Timestamp":"2025-02-19T01:58:53.6089251"},{"DeviceId":1,"Name":"Регистр 2","Description":"Описание регистра 2","Values":[],"Id":3,"Timestamp":"2025-02-19T01:58:53.6089263"}],"Id":1,"Timestamp":"2025-02-19T01:58:53.6083232"},"Method":"DELETE","TableName":"DEVICE"}
# Запустить генератор
http://127.0.0.1:9999/?json={"Method":"START","TableName":"GENERATOR"}
# Остановить генератор
http://127.0.0.1:9999/?json={"Method":"STOP","TableName":"GENERATOR"}
# Получить последние 1000 логов
http://127.0.0.1:9999/?json={"Method":"GET_LATEST","TableName":"LOG"}

