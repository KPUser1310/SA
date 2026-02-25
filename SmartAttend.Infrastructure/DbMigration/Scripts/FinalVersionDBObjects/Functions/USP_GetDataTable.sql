-- FUNCTION: public.usp_getdatatable(integer, bigint, integer, integer)

-- DROP FUNCTION IF EXISTS public.usp_getdatatable(integer, bigint, integer, integer);

CREATE OR REPLACE FUNCTION public.usp_getdatatable(
	p_accountid integer,
	p_deviceid bigint,
	p_pagenumber integer,
	p_pagesize integer)
    RETURNS TABLE("Id" integer, "DeviceId" bigint, "AccountId" integer, "DeviceDataUserMapId" integer, "InputName" text, "Message" text, "CustomMessage" text, "ContactFromHours" text, "ContactToHours" text, "Reminder" integer, "SentDate" timestamp with time zone, "IsNotify" boolean, "IsActive" boolean, "EntityType" integer, "CompletedReason" text, "CreatedDate" timestamp with time zone, "UpdatedDate" timestamp with time zone, "RowNumber" bigint) 
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
BEGIN

    IF (p_accountid > 0 AND p_deviceid = 0) THEN
        RETURN QUERY
        SELECT 
            n."Id",
            n."DeviceId",
            n."AccountId",
            n."DeviceDataUserMapId",
            n."InputName",
            n."Message",
            n."CustomMessage",
            n."ContactFromHours",
            n."ContactToHours",
            n."Reminder",
            n."SentDate",
            n."IsNotify",
            n."IsActive",
            n."EntityType",
            n."CompletedReason",
            n."CreatedDate",
            n."UpdatedDate",
            ROW_NUMBER() OVER (
                PARTITION BY n."DeviceId"
                ORDER BY n."UpdatedDate" DESC
            ) AS "RowNumber"
        FROM "Notifications" n
        WHERE n."IsNotify" = false
          AND n."AccountId" = p_accountid
        GROUP BY
            n."Id",n."DeviceId",n."AccountId",n."DeviceDataUserMapId",n."InputName",
            n."Message",n."CustomMessage",n."ContactFromHours",n."ContactToHours",
            n."Reminder",n."SentDate",n."IsNotify",n."IsActive",n."EntityType",
            n."CompletedReason",n."CreatedDate",n."UpdatedDate"
        ORDER BY n."UpdatedDate" DESC
        OFFSET p_pagesize * (p_pagenumber - 1)
        LIMIT p_pagesize;

    ELSIF (p_accountid > 0 AND p_deviceid > 0) THEN
        RETURN QUERY
        SELECT 
            n."Id",
            n."DeviceId",
            n."AccountId",
            n."DeviceDataUserMapId",
            n."InputName",
            n."Message",
            n."CustomMessage",
            n."ContactFromHours",
            n."ContactToHours",
            n."Reminder",
            n."SentDate",
            n."IsNotify",
            n."IsActive",
            n."EntityType",
            n."CompletedReason",
            n."CreatedDate",
            n."UpdatedDate",
            ROW_NUMBER() OVER (
                PARTITION BY n."DeviceId"
                ORDER BY n."UpdatedDate" DESC
            ) AS "RowNumber"
        FROM "Notifications" n
        WHERE n."AccountId" = p_accountid
          AND n."IsNotify" = false
          AND n."DeviceId" = p_deviceid
        GROUP BY
            n."Id",n."DeviceId",n."AccountId",n."DeviceDataUserMapId",n."InputName",
            n."Message",n."CustomMessage",n."ContactFromHours",n."ContactToHours",
            n."Reminder",n."SentDate",n."IsNotify",n."IsActive",n."EntityType",
            n."CompletedReason",n."CreatedDate",n."UpdatedDate"
        ORDER BY n."UpdatedDate" DESC
        OFFSET p_pagesize * (p_pagenumber - 1)
        LIMIT p_pagesize;

    ELSE
        RETURN QUERY
        SELECT 
            n."Id",
            n."DeviceId",
            n."AccountId",
            n."DeviceDataUserMapId",
            n."InputName",
            n."Message",
            n."CustomMessage",
            n."ContactFromHours",
            n."ContactToHours",
            n."Reminder",
            n."SentDate",
            n."IsNotify",
            n."IsActive",
            n."EntityType",
            n."CompletedReason",
            n."CreatedDate",
            n."UpdatedDate",
            ROW_NUMBER() OVER (
                PARTITION BY n."DeviceId"
                ORDER BY n."UpdatedDate" DESC
            ) AS "RowNumber"
        FROM "Notifications" n
        WHERE n."AccountId" = p_accountid
          AND n."IsNotify" = false
        GROUP BY
            n."Id",n."DeviceId",n."AccountId",n."DeviceDataUserMapId",n."InputName",
            n."Message",n."CustomMessage",n."ContactFromHours",n."ContactToHours",
            n."Reminder",n."SentDate",n."IsNotify",n."IsActive",n."EntityType",
            n."CompletedReason",n."CreatedDate",n."UpdatedDate"
        ORDER BY n."UpdatedDate" DESC
        OFFSET p_pagesize * (p_pagenumber - 1)
        LIMIT p_pagesize;
    END IF;

END;
$BODY$;

ALTER FUNCTION public.usp_getdatatable(integer, bigint, integer, integer)
    OWNER TO sadashboard;
