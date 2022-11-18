import { Arguments, CommandBuilder } from 'yargs';

type Options = {
	text: string;
	min: number | undefined;
	max: number | undefined;
};

export const command: string = 'anagrams <text>';
export const description: string = 'Retrieve anagrams for the given <text>';

// create builder
export const builder: CommandBuilder<Options, Options> = (yargs) =>
	yargs
		.options({
			min: { type: 'number', alias: 'm', desc: 'The minimum word length to return' },
			max: { type: 'number', alias: 'x', desc: 'The maximum word length to return' }
		})

		.positional('text', { type: 'string', demandOption: true });

// create handler
export const handler = (argv: Arguments<Options>): void => {
	const { text, min, max } = argv;

	// get anagrams from arguments
	const anagrams = ['den','end','dane','dean','dance'];

	process.stdout.write(`retrieving anagrams for '${text}'... between ${min ?? 3} and ${max ?? text.length} letters`);
	process.exit(0);
};