# Url-Scanner REST API service
## How to run locally
### Build the service
1. Open solution by Visual Studio
2. Choose Build and Build Solution

### Run the service
The service can run in IISExpress, Console or Docker and the process is similar for all three environments. This instruction will show how to run in IISExpress.
1. In Visual Studio, choose IISExpress as Debug Profile
2. Start Debugging
3. Default endpoint will open at https://localhost:44316/urlscanner
4. Browser would show "This is an WebApi for URL scanner"

### Call the service
The service can be requested by any api client. This instruction will show how to send request using Postman
1. Run the service
2. Open Postman
3. Create new request with:
- URL: https://localhost:44316/urlscanner/scan
- Type: POST
- Body: Text to analyze
4. Click Send
5. Service would return a list of Urls that are found in the text

### Some tests
During the implementation, I wrote some unit tests and these cases can be replicated using Postman.
1. Empty case
- Input: Empty
- Output: Empty list

2. String contains some Urls 
- Input: Visit photo hosting sites such as www.flickr.com, 500px.com, www.freeimagehosting.net and https://postimage.io, and upload these two image files, picture.dog.png and picture.cat.jpeg, there. After that share their links at https://www.facebook.com/ and http://🍕.ws
- Output: [
    "http://www.flickr.com",
    "http://500px.com",
    "http://www.freeimagehosting.net",
    "https://postimage.io",
    "https://www.facebook.com/",
    "http://🍕.ws"
]

3. Duplicated cases
- Input: Visit google.com and http://google.com
- Output: [
    "http://google.com"
]
