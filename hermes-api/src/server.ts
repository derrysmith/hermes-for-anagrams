import api from './api';

// http://localhost:1234
const port = process.env.PORT || 1234;

api.listen(port, () => {
	console.log(`listening on port ${port}`);
});