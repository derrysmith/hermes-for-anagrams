import http from 'http';
const port = 1234;


const server = http.createServer((request, response) => {
	//response.statusCode = 200;
	response.write('hello world');
	response.end();
});

server.listen(port, () => {
	console.log(`server is running on port ${port}`);
	console.log(`navigate to http://localhost:${port}`);
});

//server.close();