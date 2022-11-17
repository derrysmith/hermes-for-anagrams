import { IDictionaryService } from "./IDictionaryService";

export interface IDictionaryServiceProvider {
	get(language: string): IDictionaryService | undefined;
}