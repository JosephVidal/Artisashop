/* tslint:disable */
/* eslint-disable */
/**
 * API Artisashop
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
import type { Account } from './Account';
import {
    AccountFromJSON,
    AccountFromJSONTyped,
    AccountToJSON,
} from './Account';

/**
 * 
 * @export
 * @interface ChatMessage
 */
export interface ChatMessage {
    /**
     * 
     * @type {number}
     * @memberof ChatMessage
     */
    id?: number;
    /**
     * 
     * @type {Account}
     * @memberof ChatMessage
     */
    sender?: Account;
    /**
     * 
     * @type {Account}
     * @memberof ChatMessage
     */
    receiver?: Account;
    /**
     * 
     * @type {Date}
     * @memberof ChatMessage
     */
    date?: Date;
    /**
     * 
     * @type {string}
     * @memberof ChatMessage
     */
    content?: string | null;
    /**
     * 
     * @type {string}
     * @memberof ChatMessage
     */
    joined?: string | null;
    /**
     * 
     * @type {string}
     * @memberof ChatMessage
     */
    filename?: string | null;
}

/**
 * Check if a given object implements the ChatMessage interface.
 */
export function instanceOfChatMessage(value: object): boolean {
    let isInstance = true;

    return isInstance;
}

export function ChatMessageFromJSON(json: any): ChatMessage {
    return ChatMessageFromJSONTyped(json, false);
}

export function ChatMessageFromJSONTyped(json: any, ignoreDiscriminator: boolean): ChatMessage {
    if ((json === undefined) || (json === null)) {
        return json;
    }
    return {
        
        'id': !exists(json, 'id') ? undefined : json['id'],
        'sender': !exists(json, 'sender') ? undefined : AccountFromJSON(json['sender']),
        'receiver': !exists(json, 'receiver') ? undefined : AccountFromJSON(json['receiver']),
        'date': !exists(json, 'date') ? undefined : (new Date(json['date'])),
        'content': !exists(json, 'content') ? undefined : json['content'],
        'joined': !exists(json, 'joined') ? undefined : json['joined'],
        'filename': !exists(json, 'filename') ? undefined : json['filename'],
    };
}

export function ChatMessageToJSON(value?: ChatMessage | null): any {
    if (value === undefined) {
        return undefined;
    }
    if (value === null) {
        return null;
    }
    return {
        
        'id': value.id,
        'sender': AccountToJSON(value.sender),
        'receiver': AccountToJSON(value.receiver),
        'date': value.date === undefined ? undefined : (value.date.toISOString()),
        'content': value.content,
        'joined': value.joined,
        'filename': value.filename,
    };
}

