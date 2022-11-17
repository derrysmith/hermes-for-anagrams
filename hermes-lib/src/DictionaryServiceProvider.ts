import { injectable, injectAll } from "tsyringe";
import { IDictionaryService } from "./IDictionaryService";
import { IDictionaryServiceProvider } from "./IDictionaryServiceProvider";
import { types } from "./types";

@injectable()
export class DictionaryServiceProvider implements IDictionaryServiceProvider {
	constructor(@injectAll(types.IDictionaryService) private dictionaryServices: IDictionaryService[]) { }

	get(language: string): IDictionaryService | undefined {
		return this.dictionaryServices.find(svc => svc.language === language);
	}
}