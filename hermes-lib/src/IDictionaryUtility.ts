export interface IDictionaryUtility {
	createDictionary(language: string): Map<string, string[]>;
}