import "reflect-metadata";

import { container, inject } from "tsyringe";

import { IDictionaryService } from "./IDictionaryService";
import { IDictionaryServiceProvider } from "./IDictionaryServiceProvider";
import { IDictionaryUtility } from "./IDictionaryUtility";
import { DictionaryService } from "./DictionaryService";
import { DictionaryServiceProvider } from "./DictionaryServiceProvider";
import { DictionaryUtility } from "./DictionaryUtility";
import { types } from "./types";

container.register(types.IDictionaryService, { useFactory: (c) =>
	new DictionaryService('en', c.resolve<IDictionaryUtility>(types.IDictionaryUtility)) });

// container.register(types.IDictionaryService, { useFactory: (c) =>
// 	new DictionaryService('es', c.resolve<IDictionaryUtility>(types.IDictionaryUtility)) });

container.register(types.IDictionaryServiceProvider, { useClass: DictionaryServiceProvider });

container.register(types.IDictionaryUtility, { useClass: DictionaryUtility });

export {
	IDictionaryUtility,
	IDictionaryService,
	IDictionaryServiceProvider,
	types
}