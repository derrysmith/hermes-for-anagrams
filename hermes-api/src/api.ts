import express, { Application } from 'express';
import bparser from 'body-parser';

import { GetAnagramsRoute } from './routes/anagrams';

const api: Application = express();
api.use(bparser.json());

const getAnagramsRoute = new GetAnagramsRoute();
getAnagramsRoute.routes(api);

export default api;