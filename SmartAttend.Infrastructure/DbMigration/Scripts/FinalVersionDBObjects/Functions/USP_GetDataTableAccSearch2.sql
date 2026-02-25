-- FUNCTION: public.usp_getdatatableaccsearch2(integer, bigint, integer, integer, integer)

-- DROP FUNCTION IF EXISTS public.usp_getdatatableaccsearch2(integer, bigint, integer, integer, integer);

CREATE OR REPLACE FUNCTION public.usp_getdatatableaccsearch2(
	p_accountid integer,
	p_deviceid bigint,
	p_pagenumber integer,
	p_pagesize integer,
	p_status integer)
    RETURNS TABLE("Id" integer, "DeviceId" bigint, "AccountId" integer, "DeviceDataUserMapId" integer, "InputName" text, "Message" text, "CustomMessage" text, "ContactFromHours" text, "ContactToHours" text, "Reminder" integer, "SentDate" timestamp with time zone, "IsNotify" boolean, "IsActive" boolean, "EntityType" integer, "CompletedReason" text, "CreatedDate" timestamp with time zone, "UpdatedDate" timestamp with time zone, "RowNumber" bigint) 
    LANGUAGE 'plpgsql'
    COST 100
    VOLATILE PARALLEL UNSAFE
    ROWS 1000

AS $BODY$
BEGIN

    IF (p_accountid > 0 AND p_status = 1 AND p_deviceid = 0) THEN
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
        INNER JOIN "Devices" d ON n."DeviceId" = d."DeviceId"
        WHERE n."IsNotify" = TRUE
          AND n."AccountId" = p_accountid
          AND d."IsActive" = TRUE
        ORDER BY n."UpdatedDate" DESC
        LIMIT p_pagesize
        OFFSET GREATEST(p_pagesize * (p_pagenumber - 1), 0);

    ELSIF (p_accountid > 0 AND p_status = 1 AND p_deviceid > 0) THEN
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
        INNER JOIN "Devices" d ON n."DeviceId" = d."DeviceId"
        WHERE n."IsNotify" = TRUE
          AND n."AccountId" = p_accountid
          AND n."DeviceId" = p_deviceid
          AND d."IsActive" = TRUE
        ORDER BY n."UpdatedDate" DESC
        LIMIT p_pagesize
        OFFSET GREATEST(p_pagesize * (p_pagenumber - 1), 0);

    ELSIF (p_accountid > 0 AND p_status = 0 AND p_deviceid = 0) THEN
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
        INNER JOIN "Devices" d ON n."DeviceId" = d."DeviceId"
        WHERE n."IsNotify" = FALSE
          AND n."AccountId" = p_accountid
          AND d."IsActive" = TRUE
        ORDER BY n."UpdatedDate" DESC
        LIMIT p_pagesize
        OFFSET GREATEST(p_pagesize * (p_pagenumber - 1), 0);

    ELSIF (p_accountid > 0 AND p_status = 0 AND p_deviceid > 0) THEN
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
        INNER JOIN "Devices" d ON n."DeviceId" = d."DeviceId"
        WHERE n."IsNotify" = FALSE
          AND n."AccountId" = p_accountid
          AND n."DeviceId" = p_deviceid
          AND d."IsActive" = TRUE
        ORDER BY n."UpdatedDate" DESC
        LIMIT p_pagesize
        OFFSET GREATEST(p_pagesize * (p_pagenumber - 1), 0);

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
        INNER JOIN "Devices" d ON n."DeviceId" = d."DeviceId"
        WHERE n."AccountId" = p_accountid
          AND n."IsNotify" = FALSE
          AND d."IsActive" = TRUE
        ORDER BY n."UpdatedDate" DESC
        LIMIT p_pagesize
        OFFSET GREATEST(p_pagesize * (p_pagenumber - 1), 0);
    END IF;

END;
$BODY$;

ALTER FUNCTION public.usp_getdatatableaccsearch2(integer, bigint, integer, integer, integer)
    OWNER TO sadashboard;
