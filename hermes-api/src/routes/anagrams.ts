import { Application, Request, Response } from 'express';

export class GetAnagramsRoute {
	public routes(api: Application): void {
		api.route('/anagrams').get((req: Request, res: Response) => {
			const anagrams = ['den','end','dane','dean','dance'];
			res.status(200).send({ anagrams });
		});
	}
}