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
/**
 * 
 * @export
 * @interface CreateChatMessage
 */
export interface CreateChatMessage {
    /**
     * 
     * @type {string}
     * @memberof CreateChatMessage
     */
    fromUserId: string;
    /**
     * 
     * @type {string}
     * @memberof CreateChatMessage
     */
    toUserID: string;
    /**
     * 
     * @type {string}
     * @memberof CreateChatMessage
     */
    filename?: string | null;
    /**
     * 
     * @type {string}
     * @memberof CreateChatMessage
     */
    content: string;
    /**
     * 
     * @type {string}
     * @memberof CreateChatMessage
     */
    joined?: string | null;
}

/**
 * Check if a given object implements the CreateChatMessage interface.
 */
export function instanceOfCreateChatMessage(value: object): boolean {
    let isInstance = true;
    isInstance = isInstance && "fromUserId" in value;
    isInstance = isInstance && "toUserID" in value;
    isInstance = isInstance && "content" in value;

    return isInstance;
}

export function CreateChatMessageFromJSON(json: any): CreateChatMessage {
    return CreateChatMessageFromJSONTyped(json, false);
}

export function CreateChatMessageFromJSONTyped(json: any, ignoreDiscriminator: boolean): CreateChatMessage {
    if ((json === undefined) || (json === null)) {
        return json;
    }
    return {
        
        'fromUserId': json['fromUserId'],
        'toUserID': json['toUserID'],
        'filename': !exists(json, 'filename') ? undefined : json['filename'],
        'content': json['content'],
        'joined': !exists(json, 'joined') ? undefined : json['joined'],
    };
}

export function CreateChatMessageToJSON(value?: CreateChatMessage | null): any {
    if (value === undefined) {
        return undefined;
    }
    if (value === null) {
        return null;
    }
    return {
        
        'fromUserId': value.fromUserId,
        'toUserID': value.toUserID,
        'filename': value.filename,
        'content': value.content,
        'joined': value.joined,
    };
}

