/* tslint:disable */
/* eslint-disable */
/**
 * API Artichaut
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
 *
 * The version of the OpenAPI document: v1
 * 
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */

import { exists, mapValues } from '../runtime';
/**
 * 
 * @export
 * @interface ChatHistory
 */
export interface ChatHistory {
    /**
     * 
     * @type {string}
     * @memberof ChatHistory
     */
    userIDOne?: string | null;
    /**
     * 
     * @type {string}
     * @memberof ChatHistory
     */
    userIDTwo?: string | null;
}

/**
 * Check if a given object implements the ChatHistory interface.
 */
export function instanceOfChatHistory(value: object): boolean {
    let isInstance = true;

    return isInstance;
}

export function ChatHistoryFromJSON(json: any): ChatHistory {
    return ChatHistoryFromJSONTyped(json, false);
}

export function ChatHistoryFromJSONTyped(json: any, ignoreDiscriminator: boolean): ChatHistory {
    if ((json === undefined) || (json === null)) {
        return json;
    }
    return {
        
        'userIDOne': !exists(json, 'userIDOne') ? undefined : json['userIDOne'],
        'userIDTwo': !exists(json, 'userIDTwo') ? undefined : json['userIDTwo'],
    };
}

export function ChatHistoryToJSON(value?: ChatHistory | null): any {
    if (value === undefined) {
        return undefined;
    }
    if (value === null) {
        return null;
    }
    return {
        
        'userIDOne': value.userIDOne,
        'userIDTwo': value.userIDTwo,
    };
}

