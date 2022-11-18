#!/usr/bin/env node

import yargs from 'yargs';
import { hideBin } from 'yargs/helpers';

yargs(hideBin(process.argv))
	// scaffold in commands directory
	.commandDir('commands')
	// enable strict mode
	.strict()
	// aliases
	.alias({'h': 'help'})
	.alias({'?': 'help'})
	.alias({'v': 'version'})
	.argv;