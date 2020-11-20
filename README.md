# Practical.API
.NET CORE Practical Test API

Application is running on 64109 port

Navigate to http://localhost:64109/swagger for swagger documentation

HTTPGET - http://localhost:64109/api/colors - to get all colors from JSON file

HTTPGET - http://localhost:64109/api/colors/Find?id=black - to find color entry from JSON file

HTTPPOST - http://localhost:64109/api/colors - to create new color entry in JSON file (pass color in request body)

HTTPPUT - http://localhost:64109/api/colors - to modify color entry in JSON file (pass color in request body)

HTTPDELETE - http://localhost:64109/api/colors?id=black - to delete color entry in JSON file

HTTPGET - http://localhost:64109/api/Colors/RaiseError - to test exception handler middleware

*** START VISUAL STUDIO AS ADMINISTRATOR
