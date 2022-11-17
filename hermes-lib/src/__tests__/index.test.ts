import "reflect-metadata";
import { container } from 'tsyringe';
import { IDictionaryServiceProvider, types } from '../index';

test('get anagrams', () => {
	const dictionaryServiceProvider = container.resolve<IDictionaryServiceProvider>(types.IDictionaryServiceProvider);
	const dictionaryService = dictionaryServiceProvider.get('en');

	const anagrams = dictionaryService!.getAnagrams('english', 5, 7);
	
	expect(anagrams.length).toBe(36);
});