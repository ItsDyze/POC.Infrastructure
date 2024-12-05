db.auth('dev', 'dev')

db = db.getSiblingDB('Integration_RINF')

db.createUser({
    user: 'dev',
    pwd: 'dev',
    roles: [
        {
            role: 'root',
            db: 'Integration_RINF',
        },
    ],
});